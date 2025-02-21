using UnityEngine;

[RequireComponent (typeof(InteractableObject))]
public class HighlightInteractiveObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 

    private Color originalColor; 
    public Color hoverColor = Color.yellow;  //� ���������� ����� ������� ����� ���������

    private InteractableObject interactableObject;
    private bool _isInteractable = false;

    private void Start()
    {
        // �������� ��������� SpriteRenderer �������
        spriteRenderer = GetComponent<SpriteRenderer>();

        interactableObject = GetComponent<InteractableObject>();
        // ��������� ������������ ����
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
