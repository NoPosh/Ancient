using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour, IInitializable
{
    //Скрипт движения персонажа
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Set in inspector")]
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _jumpForce = 10f;

    private bool _isInitialized = false;
    private bool _isGrounded = false;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Transform groundCheck;

    
    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _isInitialized = true;
    }

    private void FixedUpdate()
    {
        if (!_isInitialized) return;    
        Move();
        CheckGround();
    }

    private void Update()
    {
        if (!_isInitialized) return;
        animator.SetFloat("Velocity", Mathf.Abs(rb.linearVelocityX));
        
        if (rb.linearVelocityX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(rb.linearVelocityX), 1, 1);
        }


        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2 (horizontal, 0).normalized;

        rb.linearVelocity = new Vector2(direction.x * _movementSpeed, rb.linearVelocity.y);

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    private void Jump()
    {
        if (!_isGrounded) return;
        bool jump = Input.GetButtonDown("Jump");
        rb.linearVelocityY = _jumpForce;
        //rb.AddForce(Vector2.up * _jumpForce);
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("IsGrounded", _isGrounded);
    }

 
}
