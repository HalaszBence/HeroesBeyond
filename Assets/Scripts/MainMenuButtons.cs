using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button playButton = root.Q<Button>("PlayButton");
        Button exitButton = root.Q<Button>("ExitButton");

        playButton.clicked += StartGame;
        exitButton.clicked += Exit;
    }

    public void StartGame() {
        Debug.Log("Starting the game");
    }

    public void Exit() {
        Application.Quit();
    }
}
