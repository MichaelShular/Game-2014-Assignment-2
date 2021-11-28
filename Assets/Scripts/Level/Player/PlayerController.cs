using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    
    public float horizontalForce;
    public float verticalForce;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float x = (Input.GetAxisRaw("Horizontal")) ;

        
        float y = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");


        float horizontalMoveForce = x * horizontalForce;
        float jumpMoveForce = jump * verticalForce;

        float mass = playerRigidbody.mass * playerRigidbody.gravityScale;


            playerRigidbody.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
            playerRigidbody.velocity *= 0.99f; // scaling / stopping hack
    }
       

}
