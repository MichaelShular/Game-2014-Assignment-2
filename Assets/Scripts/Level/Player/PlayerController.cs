//Michael Shular 101273089
//PlayerController 
//12/12/2021
//Summary: Controls aspects of the player. Such as movement, when player is touch the ground, 
// when player can jump or shoot, animation, and UI button presses. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [Header("Control Forces")]
    [SerializeField] private float horizontalForce;
    [SerializeField] private float verticalForce;
    [Range(0.1f, 0.9f)]
    [SerializeField] private float airControlFactor;
    private float jumpButton;
   
    [Header("Grounded Settings")]
    private bool isGrounded;
    [SerializeField] private Transform groundOrigin;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask groundLayerMask;
    private GameStateController gameController;

    [Header("Bullet")]
    [SerializeField] private GameObject playerBullet;

    public bool isTouchingCrank;
    public bool pushedCrank;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameStateController>();
        isTouchingCrank = false;
        pushedCrank = false;
    }
    void FixedUpdate()
    {
        Movement();
        CheckIfGrounded();
    } 
    private void Movement()
    {
        float x = (Input.GetAxisRaw("Horizontal")) ;
        if (x != 0)
        {
            x = FlipAnimation(x);
        }
        if (isGrounded)
        {
            float jump = Input.GetAxisRaw("Jump") + jumpButton;
            movementCalulation(x, jump, 1);
            playerRigidbody.velocity *= 0.99f; // scaling / stopping hack
        }
        else //Air control
        {
            if (x != 0)
            {
                movementCalulation(x, 0, airControlFactor);
            }
        }
    }

    //Amount for force applyed to player
    private void movementCalulation(float xInput, float yInput, float airForce)
    {
        float horizontalMoveForce = xInput * horizontalForce * airForce;
        float jumpMoveForce = yInput * verticalForce;
        float mass = playerRigidbody.mass * playerRigidbody.gravityScale;
        playerRigidbody.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
        jumpButton = 0;
    }

    //Using a layermask and the radius around groundOrigin to check if player is touching the ground 
    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);
        isGrounded = (hit) ? true : false;
    }

    //Changing local transformation base on x intput 
    private float FlipAnimation(float x)
    {
        x = (x > 0) ? 1 : -1;
        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //visualizating radius around  groundOrigin
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }

    public void shootAcorn()
    {
        if (gameController.getAmmo() > 0)
        {
            gameController.incrementOrDecrementAmmo(-1);
            GameObject temp = Instantiate(playerBullet);
            temp.transform.position = transform.position;
            temp.GetComponent<PlayerBullet>().setDirection(new Vector3(transform.localScale.x, 0.0f, 0.0f));
        }
    }

    public void jump()
    {
        //jumpButton = 3;
    }

    public void growCrank()
    {
        if (isTouchingCrank)
        {
            pushedCrank = true;
        }
    }
}
