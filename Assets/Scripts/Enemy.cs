using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly string ANIM_PARAM_NAME = "AnimState";

    enum State
    {
        Idle = 6,
        Run = 2,
        Dead = 4,
        Attack = 3,
        Hurt = 5
    }

    public int Health = 20;
    public float MaxWalkingDistance = 3f;
    public float MovementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 StartingPosition;
    private bool IsFacingRight = false;
    public SFXManager sfx;
    private Animator animator;
    private bool canRun = true;
    [SerializeField] bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartingPosition = this.rb.position;
        this.animator = GetComponent<Animator>();
        SetState(State.Run);
    }

    void FixedUpdate()
    {
        if (canRun)
        {
            StartMoving();
            if (!CanKeepMoving())
            {
                SwitchDirection();
            }
        }
    }

    private void SwitchDirection()
    {
        Flip();
        StartMoving();
    }

    void StartMoving()
    {
        this.rb.velocity = new Vector2((IsFacingRight ? 1 : -1) * this.MovementSpeed, this.rb.velocity.y);
    }

    void StopMoving()
    {
        this.rb.velocity = Vector2.zero;
        this.canRun = false;
    }

    private bool CanKeepMoving()
    {
        var startX = this.StartingPosition.x;
        var currX = this.rb.position.x;

        var dX = this.rb.position.x - this.StartingPosition.x;
        return Math.Abs(dX) < MaxWalkingDistance;
    }

    public void TakeDamage(int damage)
    {
        StopMoving();
        sfx.playHurt();

        Health -= damage;
        if (!isDead && Health <= 0)
        {
            SetState(State.Dead);
            isDead = true;
            return;
        }

        SetState(State.Hurt);
    }

    public void HurtAnimationDone()
    {
        if (!isDead)
        {
            canRun = true;
            StartMoving();
            SetState(State.Run);
        }
    }

    public void DeathAnimationDone()
    {
        Die();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void SetState(State state)
    {
        this.animator.SetInteger(ANIM_PARAM_NAME, (int)state);
    }
}