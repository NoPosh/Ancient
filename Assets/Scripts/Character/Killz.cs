using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Killz : MonoBehaviour
{
    [SerializeField] float _killZPosition = -30;


    [SerializeField]private Button _resetButton;

    
    private void Start()
    {
        _resetButton.gameObject.SetActive(false);
        _resetButton.onClick.AddListener(ReloadScene);
    }

    private void Update()
    {
        if (transform.position.y <= _killZPosition) //Реализация не очень)
        {
            _resetButton.gameObject.SetActive(true);
            //По хорошему еще передвижение отключить (или персонажа убить)
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
