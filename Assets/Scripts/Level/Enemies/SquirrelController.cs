//Michael Shular 101273089
//SquirrelController
//12/13/2021
//Summary: Controls movement of squirrel, flip local scale and stun state

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private Animator animatorController;
    [Header("Movement")]
    [SerializeField] private float runForce;
    //[SerializeField] private LayerMask groundLayerMask;
    public Transform lookAheadPointGround;
    public bool isGroundAhead;
    public bool isJumping;
    [SerializeField] private Transform groundOrigin;
    [SerializeField] private float groundRadius;
    public bool isGrounded;
    public Transform lookAheadPointWall;
    private bool isStunned;
    [SerializeField] private float stunTime;
    [Header("StunAnimation")]
    [SerializeField] private GameObject stunAnimation;


    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        isJumping = false;
        isStunned = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStunned)
        {
            movement();
        }
    }
    private void movement()
    {
        animatorController.SetInteger("AnimationState", 0);
        enemyRigidbody.AddForce(Vector2.left * runForce * transform.localScale.x);
        enemyRigidbody.velocity *= 0.90f;
    }
    public void jumpForce(Vector2 forceamount)
    {
        animatorController.SetInteger("AnimationState", 1);
        enemyRigidbody.AddForce(forceamount, ForceMode2D.Impulse);
    }

    public void Flip(int a)
    {
        transform.localScale = new Vector3(a, transform.localScale.y, transform.localScale.z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //visualizating radius around  groundOrigin
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }
    public void gotStunned()
    {
        isStunned = true;
        StartCoroutine(unstunTimer());
    }
    IEnumerator unstunTimer()
    {
        //StunnedState
        stunAnimation.SetActive(true);
        animatorController.SetInteger("AnimationState", 2);
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
        stunAnimation.SetActive(false);
    }
}
