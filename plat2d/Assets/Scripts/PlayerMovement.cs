using UnityEngine;

public enum PlayerState
{
    Idle = 0,
    Running = 1,
    Jumping = 2,
    Falling = 3,
    Climbing = 4
}

public class PlayerMovement : MonoBehaviour
{
    private const string STATE_PARAM_NAME = "state";
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerState state;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider_;

    [SerializeField]
    private LayerMask jumpableGround;
    private float xVelocity = 0f;

    public float JumpForce = 7;
    public float HorizontalSpeed = 4;


    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.state = PlayerState.Idle;
        this.collider_ = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        this.xVelocity = Input.GetAxisRaw("Horizontal");
        this.rb.velocity = new Vector2(HorizontalSpeed * this.xVelocity, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            this.rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        if (xVelocity > 0f)
        {
            this.state = PlayerState.Running;
            this.spriteRenderer.flipX = false;
        }
        else if (xVelocity < 0f)
        {
            this.state = PlayerState.Running;
            this.spriteRenderer.flipX = true;
        }
        else
        {
            this.state = PlayerState.Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            this.state = PlayerState.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            this.state = PlayerState.Falling;
        }

        this.animator.SetInteger(STATE_PARAM_NAME, (int)this.state);
    }

    private bool IsGrounded() 
    {
       return Physics2D.BoxCast(
            collider_.bounds.center,
            collider_.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            jumpableGround
        );
    }
}
