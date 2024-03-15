using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    VisualElement root;
    
    void Start() {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    void Update() {
        if(root.Q<ProgressBar>("LoadingBar").value == 100) {
            SceneManager.LoadScene("MenuScene");    
        }
        else {
            root.Q<ProgressBar>("LoadingBar").value += 0.25f;   
        }
    }
}
