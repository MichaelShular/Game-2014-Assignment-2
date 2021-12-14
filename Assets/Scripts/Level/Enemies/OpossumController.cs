//Michael Shular 101273089
//OpossumController
//12/13/2021
//Summary: Controls movement of opossum and if can see player.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumController : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private GameStateController gameController;
    [Header("Movement")]
    [SerializeField] private float runForceMin;
    [SerializeField] private float runForceMax;
    private float runForceCurrent;
    public Transform lookAheadPointPlayer;
    [SerializeField] private LayerMask playerLayerMask;
    private bool canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        canSeePlayer = false;
        enemyRigidbody = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameStateController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckIfSeesPlayer();
        if (canSeePlayer)
        {
            runForceCurrent = runForceMax;
        }
        else
        {
            runForceCurrent = runForceMin;
        }
        movement();
    }
    private void movement()
    {
        enemyRigidbody.AddForce(Vector2.left * runForceCurrent);
        enemyRigidbody.velocity *= 0.90f;
    }

    private void CheckIfSeesPlayer()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, lookAheadPointPlayer.position, playerLayerMask);
        canSeePlayer = (hit) ? true : false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            collision.gameObject.GetComponent<PlayerController>().hurtState();
            gameController.triggerPlayerSpawn(collision);
            gameController.incrementOrDecrementPlayerLives(-1);
        }
        if (collision.gameObject.CompareTag("DeathPlane"))
        {
            Destroy(this.gameObject);
        }
    }

}
