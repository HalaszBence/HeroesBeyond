using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using UnityEngine.Android;

public class LobbySystem : MonoBehaviour
{   
    private const string KEY = "RelayJoinCode";
    public static LobbySystem Instance {get; private set;}
    private static int LobbySize = 2;
    private Lobby joinedLobby;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeUnityAuthentication();
    }

    private async void InitializeUnityAuthentication() {
        if(UnityServices.State != ServicesInitializationState.Initialized) {
            InitializationOptions initializationOptions = new InitializationOptions();
            initializationOptions.SetProfile(UnityEngine.Random.Range(0, 10000).ToString()); 

            await UnityServices.InitializeAsync(initializationOptions);

            await AuthenticationService.Instance.SignInAnonymouslyAsync();    
        }
    }

    public async void CreateLobby() {
        CreateLobbyOptions options = new CreateLobbyOptions();
        options.IsPrivate = false;
        options.Data = new Dictionary<string, DataObject>()
        {
            {
                "MinimumSkillLevel", new DataObject(
                    visibility: DataObject.VisibilityOptions.Public,
                    value: "master",
                    index: DataObject.IndexOptions.S1
                )
            },
        };

        try {
            joinedLobby = await LobbyService.Instance.CreateLobbyAsync("Lobby1", LobbySize, options);

            Allocation allocation = await AllocateRelay();

            string relayJoinCode = await GetRelayJoinCode(allocation);

            await LobbyService.Instance.UpdateLobbyAsync(joinedLobby.Id, new UpdateLobbyOptions {
                Data = new Dictionary<string, DataObject>() {
                    {KEY, new DataObject(DataObject.VisibilityOptions.Member, relayJoinCode)}
                }
            });

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));

            MultiplayerManager.Instance.StartHost();
            Loader.LoadNetwork(Loader.Scene.BoardScene);

        } catch(LobbyServiceException e) {
            Debug.Log(e);
        }
    }

    public async void FindGame() {
        QueryLobbiesOptions options = new QueryLobbiesOptions();
        options.Filters = new List<QueryFilter>() {
            new QueryFilter(QueryFilter.FieldOptions.S1, "master", QueryFilter.OpOptions.EQ),
            new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
        };

        QueryResponse lobbies = await Lobbies.Instance.QueryLobbiesAsync(options);
        if(lobbies.Results.Count() == 0) {
            Debug.Log("No lobbies were found so we create one");
            CreateLobby();
        } else {
            Debug.Log("Lobby found");
            joinedLobby = await LobbyService.Instance.JoinLobbyByIdAsync(lobbies.Results[0].Id);
            string JoinCode = joinedLobby.Data[KEY].Value;
            JoinAllocation joinAllocation = await JoinRelay(JoinCode);

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls"));

            // Debug.Log("Joined lobby: " + joinedLobby.Name);
            MultiplayerManager.Instance.StartClient();
        }
    }

     private async Task<string> GetRelayJoinCode(Allocation allocation) {
        try {
            string relayJoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            return relayJoinCode;
        } catch(RelayServiceException e) {
            Debug.Log(e);
            return default;
        }
    }

    private async Task<Allocation> AllocateRelay() {
        try {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(LobbySize-1);
            return allocation;
        } catch(RelayServiceException e) {
            Debug.Log(e);
            return default;
        }
    }

    private async Task<JoinAllocation> JoinRelay(string joinCode) {
        try {
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);
            return joinAllocation;
        } catch(RelayServiceException e) {
            Debug.Log(e);
            return default;
        }
    }
}
