using UnityEngine;
using Unity.Netcode;

public class MultiplayerManager : MonoBehaviour
{
    public static MultiplayerManager Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }

    public void StartHost() {
        // NetworkManager.Singleton.ConnectionApprovalCallback += ConnectionApprovalCallback;
        NetworkManager.Singleton.StartHost();
    }

    public void StartClient() {
        NetworkManager.Singleton.StartClient();
    }

    private void ConnectionApprovalCallback(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        response.Approved = true;
    }

    
}
