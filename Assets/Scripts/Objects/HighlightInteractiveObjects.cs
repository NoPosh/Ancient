using UnityEngine;

[RequireComponent (typeof(InteractableObject))]
public class HighlightInteractiveObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 

    private Color originalColor; 
    public Color hoverColor = Color.yellow;  //В дальнейшем можно сделать через материалы

    private InteractableObject interactableObject;
    private bool _isInteractable = false;

    private void Start()
    {
        // Получаем компонент SpriteRenderer объекта
        spriteRenderer = GetComponent<SpriteRenderer>();

        interactableObject = GetComponent<InteractableObject>();
        // Сохраняем оригинальный цвет
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private void Update()
    {
        _isInteractable = interactableObject.IsInteractive;
    }

    private void OnMouseEnter()
    {
        if (spriteRenderer != null && _isInteractable)
        {
            spriteRenderer.color = hoverColor;
        }
    }
    private void OnMouseExit()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
}
