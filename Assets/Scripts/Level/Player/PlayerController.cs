//Michael Shular 101273089
//PlayerController 
//12/13/2021
//Summary: Controls aspects of the player. Such as movement, when player is touch the ground, 
// when player can jump or shoot, animation, and UI button presses. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator animatorController;
    [Header("Control Forces")]
    [SerializeField] private float horizontalForce;
    [SerializeField] private float verticalForce;
    [Range(0.1f, 0.9f)]
    [SerializeField] private float airControlFactor;

    [Header("Grounded Settings")]
    private bool isGrounded;
    [SerializeField] private Transform groundOrigin;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask groundLayerMask;
    private GameStateController gameController;

    [Header("Bullet")]
    [SerializeField] private GameObject playerBullet;

    [Header("UI Input")]
    [SerializeField] private Joystick joystick;
    [Range(0.01f, 1.0f)]
    [SerializeField] private float sensativity;
    private float jumpButton;
    public bool isTouchingCrank;
    public bool pushedCrank;

    [Header("Background")]
    [SerializeField] private GameObject background;

    [Header("HurtAnimation")]
    public float hurtTimer;
    [SerializeField] private float hurtForce;
    private bool takenDamage;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
        gameController = GameObject.Find("GameController").GetComponent<GameStateController>();
        isTouchingCrank = false;
        pushedCrank = false;
        takenDamage = false;
    }
    void FixedUpdate()
    {
        if (!takenDamage)
        {
            Movement();
            CheckIfGrounded();
        }
    }
    private void Movement()
    {
        float x = ((Input.GetAxisRaw("Horizontal")) + joystick.Horizontal) * sensativity;
        if (x != 0)
        {
            x = FlipAnimation(x);
            //RunState
            animatorController.SetInteger("AnimationState", (int)PlayerAnimationStates.RUN);
        }
        else
        {
            //IdleState
            animatorController.SetInteger("AnimationState", (int)PlayerAnimationStates.IDLE);
        }

        if (isGrounded)
        {
            float jump = Input.GetAxisRaw("Jump") + jumpButton;

            // Touch Input
            Vector2 worldTouch = new Vector2();
            foreach (var touch in Input.touches)
            {
                worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            }
            movementCalulation(x, jump, 1);
            playerRigidbody.velocity *= 0.99f; // scaling / stopping hack
        }
        else //Air control
        {
            //JumpState
            animatorController.SetInteger("AnimationState", (int)PlayerAnimationStates.JUMP);
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
        settingBackgroundLocalScale(x);
        return x;
    }
    private void settingBackgroundLocalScale(float x)
    {
        if (x < 0)
        {
            background.transform.localScale = new Vector3(-1.0f, 1.0f);
        }
        else
        {
            background.transform.localScale = new Vector3(1.0f, 1.0f);
        }
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

    public void hurtState()
    {
        StartCoroutine(startHurtState());
    }

    IEnumerator startHurtState()
    {
        takenDamage = true;
        animatorController.SetInteger("AnimationState", (int)PlayerAnimationStates.HURT);
        playerRigidbody.AddForce(Vector2.up * hurtForce, ForceMode2D.Impulse);
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(hurtTimer);
        GetComponent<CapsuleCollider2D>().enabled = true;
        takenDamage = false;
    }
}
