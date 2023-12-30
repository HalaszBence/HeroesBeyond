using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button playButton = root.Q<Button>("PlayButton");
        Button clientButton = root.Q<Button>("ClientButton");
        Button exitButton = root.Q<Button>("ExitButton");

        playButton.clicked += StartGame;
        clientButton.clicked += JoinGame;
        exitButton.clicked += Exit;
    }

    public void StartGame() {
        LobbySystem.Instance.CreateLobby();
    }

    public void JoinGame() {
        LobbySystem.Instance.FindGame();
    }

    public void Exit() {
        Application.Quit();
    }
}
