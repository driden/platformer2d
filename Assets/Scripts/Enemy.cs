using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public int Health = 100;

    public float MaxWalkingDistance = 3f;
    public float MovementSpeed = 2f;
    private Vector2 StartingPosition;

    private bool IsFacingRight = true;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        StartingPosition = this.rb.position;
    }

    void FixedUpdate()
    {
        this.rb.velocity = CalculateVel();
        if (!CanKeepMoving())
        {
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        Flip();
        this.rb.velocity = CalculateVel();
    }

    Vector2 CalculateVel()
    {
        return new Vector2((IsFacingRight ? 1 : -1) * this.MovementSpeed, this.rb.velocity.y);
    }

    private bool CanKeepMoving()
    {
        var startX = this.StartingPosition.x;
        var currX = this.rb.position.x;

        var dX = rb.position.x - this.StartingPosition.x;
        return Math.Abs(dX) < MaxWalkingDistance;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Debug.Log(IsFacingRight ? "Right" : "Left");
        transform.Rotate(0f, 180f, 0f);
    }
}
