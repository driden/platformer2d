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
    private BoxCollider2D collider_;
    private ItemCollector ItemCollector;
    private bool IsFacingRight;
    private bool isAlive = true;


    [SerializeField]
    private LayerMask jumpableGround;
    private float xVelocity = 0f;
    private float yVelocity = 0f;
    private bool canClimb;

    public float JumpForce = 7;
    public float HorizontalSpeed = 4;
    public float ClimbSpeed = 2;


    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.state = PlayerState.Idle;
        this.collider_ = GetComponent<BoxCollider2D>();
        this.IsFacingRight = true;
    }

    void Update()
    {
        if (!isAlive) return;
        // TODO: Move the movement commands to FixedUpdate()
        this.xVelocity = Input.GetAxisRaw("Horizontal");
        this.rb.velocity = new Vector2(HorizontalSpeed * this.xVelocity, rb.velocity.y);

        if (!canClimb && Input.GetButtonDown("Jump") && IsGrounded())
        {
            this.rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        else if (canClimb && Input.GetButtonDown("Vertical"))
        {
            this.yVelocity = Input.GetAxisRaw("Vertical");
            this.rb.velocity = new Vector2(rb.velocity.x, this.yVelocity * ClimbSpeed);
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        if (xVelocity > 0f)
        {
            this.state = PlayerState.Running;
            if (!IsFacingRight) Flip();
        }
        else if (xVelocity < 0f)
        {
            this.state = PlayerState.Running;
            if (IsFacingRight) Flip();
        }
        else
        {
            this.state = PlayerState.Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            this.state = this.canClimb ? PlayerState.Climbing : PlayerState.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            this.state = this.canClimb ? PlayerState.Climbing : PlayerState.Falling;
        }

        this.animator.SetInteger(STATE_PARAM_NAME, (int)this.state);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collission trigger");
        if (collider.gameObject.CompareTag("Ladder"))
        {
            this.rb.gravityScale = 0f;
            this.canClimb = true;
        }
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Death");
            this.isAlive = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ladder"))
        {
            this.rb.gravityScale = 1f;
            this.canClimb = false;
        }
    }

    private bool IsGrounded()
    {
        var bounds = collider_.bounds;
        return Physics2D.BoxCast(
             bounds.center,
             bounds.size,
             0f,
             Vector2.down,
             0.1f,
             jumpableGround
         );
    }

    public void StopAtLadderTop(){
        this.rb.velocity = new Vector2(rb.velocity.x, 0f);
    }
    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
