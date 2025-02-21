using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        startButton.onClick.AddListener(LoadScene);
        exitButton.onClick.AddListener(ExitApp);        
    }

    void LoadScene()
    {
        
        SceneManager.LoadScene("FirstLevel");
        
    }

    void ExitApp()
    {
        Application.Quit();
    }

}
