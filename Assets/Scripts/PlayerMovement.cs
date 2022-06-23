using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    Idle = 0,
    Running = 1,
    Jumping = 2,
    Falling = 3,
    Climbing = 4,
    Dead = 5
}

public class PlayerMovement : MonoBehaviour
{
    private const string STATE_PARAM_NAME = "state";
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerState state;
    private BoxCollider2D collider_;
    private ItemCollector itemCollector;
    private bool isFacingRight;
    private bool isAlive = true;


    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float xVelocity = 0f;
    [SerializeField] private float yVelocity = 0f;
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
        this.isFacingRight = true;
    }

    void Update()
    {
        if (!isAlive) return;

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
            if (!isFacingRight) Flip();
        }
        else if (xVelocity < 0f)
        {
            this.state = PlayerState.Running;
            if (isFacingRight) Flip();
        }
        else
        {
            this.state = PlayerState.Idle;
        }

        if (this.yVelocity < -0.1f || this.yVelocity > 0.1f)
        {
            this.state = this.canClimb ? PlayerState.Climbing : PlayerState.Jumping;
        }

        animator.SetInteger(STATE_PARAM_NAME, (int)this.state);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (
            (collider.gameObject.CompareTag("Enemy")
             || collider.gameObject.CompareTag("Damage"))
            && isAlive
        )
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ladder"))
        {
            this.rb.gravityScale = 0f;
            Debug.Log("Can climb");
            this.canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ladder"))
        {
            this.rb.gravityScale = 1f;
            Debug.Log("Can't climb");
            this.canClimb = false;
        }
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

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Die()
    {
        isAlive = false;

        state = PlayerState.Dead;
        xVelocity = 0f;
        yVelocity = 0f;
        rb.velocity = new Vector2(0, 0);
        this.state = PlayerState.Dead;
        animator.SetInteger(STATE_PARAM_NAME, (int)this.state);

        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Scenes/EndGame");
    }
}