using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float movX;
    private string JUMP = "Jump";
    private string X = "Horizontal";

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody =  GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        movX = Input.GetAxisRaw(X);
        rigidbody.velocity = new Vector2(movX * 6f, rigidbody.velocity.y); //en y tiene que conservar la velocidad        

        if (Input.GetButtonDown(JUMP))
        {
            rigidbody.velocity = new Vector3(0, 15f, 0);
        }
    }
}
