using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animation;
    private SpriteRenderer sprite;
    private float xPosition;
    private string JUMP = "Jump";
    private string X = "Horizontal";
    [SerializeField] private float JUMP_FORCE_Y = 15f;
    [SerializeField] private float X_SPEED = 6f;
    

    private void Start()
    {
        animation = GetComponent<Animator>();
        rigidbody =  GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        xPosition = Input.GetAxisRaw(X);
        rigidbody.velocity = new Vector2(xPosition * X_SPEED, rigidbody.velocity.y); //en y tiene que conservar la velocidad        

        if (Input.GetButtonDown(JUMP))
        {
            rigidbody.velocity = new Vector3(0, JUMP_FORCE, 0);
        }

        HandleAnimation();
    }

    private void HandleAnimation(){
        if (PlayerIsFacingLeft())
        {
            animation.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if (PlayerIsFacingRight())
        {
            animation.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else 
        {
            animation.SetBool("isRunning", true);
        }
    }

    private bool PlayerIsFacingLeft()
    {
        return (xPosition > 0f);
    }

    private bool PlayerIsFacingRight()
    {
        return (xPosition < 0f);
    }
}
