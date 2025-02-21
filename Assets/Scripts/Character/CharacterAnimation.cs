using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Velocity", rb.linearVelocity.x);
    }
}
