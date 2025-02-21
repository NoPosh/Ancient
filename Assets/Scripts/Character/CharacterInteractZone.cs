using UnityEngine;

public class CharacterInteractZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        InteractableObject interactable = collision.gameObject.GetComponent<InteractableObject>();
        if (interactable != null && !interactable.isGlobal)
            interactable.IsInteractive = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractableObject interactable = collision.gameObject.GetComponent<InteractableObject>();
        if (interactable != null && !interactable.isGlobal)
            interactable.IsInteractive = false;
    }
}
