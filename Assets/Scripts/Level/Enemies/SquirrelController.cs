using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    [Header("Movement")]
    [SerializeField] private float runForce;
    [SerializeField] private LayerMask groundLayerMask;
    public Transform lookAheadPointGround;
    public bool isGroundAhead;
    public bool isJumping;
    [SerializeField] private Transform groundOrigin;
    [SerializeField] private float groundRadius;
    public bool isGrounded;
    public Transform lookAheadPointWall;


    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //lookAhead();
        movement();
        //CheckIfGrounded();
    }

    private void movement()
    {
        //if (lookAheadWall())
        //{
        //    jumpForce(new Vector2(0.6f, 0.9f));
        //    return;
        //}
        //if (isGroundAhead)
        //{
            enemyRigidbody.AddForce(Vector2.left * runForce * transform.localScale.x);
            enemyRigidbody.velocity *= 0.90f;
        //}
        //else
        //{
        //    if ( isGrounded && isJumping)
        //    {
        //        isJumping = false;
        //        jumpForce(new Vector2(0.5f, 1));
        //    }
        //}
    }
    //private void lookAhead()
    //{
    //    var Hit = Physics2D.Linecast(transform.position, lookAheadPointGround.position, groundLayerMask);
    //    if (Hit)
    //    {
    //        isGroundAhead = true;
    //    }
    //    else
    //    {
    //        isGroundAhead = false;

    //    }
    //}

    private bool lookAheadWall()
    {
        var Hit = Physics2D.Linecast(transform.position, lookAheadPointWall.position, groundLayerMask);
        if (Hit)
        {
            return true;
        }
        return false;
        
    }

    public void jumpForce(Vector2 forceamount)
    {
        enemyRigidbody.AddForce(forceamount, ForceMode2D.Impulse);
    }

    public void Flip(int a)
    {
        transform.localScale = new Vector3(a, transform.localScale.y, transform.localScale.z);
    }
    //private void CheckIfGrounded()
    //{
    //    RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);
    //    isGrounded = (hit) ? true : false;
    //    isJumping = true;
    //    Debug.Log("A");
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //visualizating radius around  groundOrigin
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }
}
