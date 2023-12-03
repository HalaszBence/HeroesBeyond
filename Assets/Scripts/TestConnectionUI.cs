using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class TestConnectionUI : MonoBehaviour
{
    VisualElement root;

    void Start() {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button hostButton = root.Q<Button>("Host");
        Button clientButton = root.Q<Button>("Client");

        hostButton.clicked += PlayAsHost;
        clientButton.clicked += PlayAsClient;
    }

    public void PlayAsHost() {
        NetworkManager.Singleton.StartHost();
        Debug.Log("Playing as host");
    }

    public void PlayAsClient() {
        NetworkManager.Singleton.StartClient();
        Debug.Log("Playing as client");
    }
}
