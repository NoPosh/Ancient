using UnityEngine;

public class HelpTrigger : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) canvas.SetActive(true);
    }
}
