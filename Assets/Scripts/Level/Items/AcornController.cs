//Michael Shular 101273089
//AcornController
//12/12/2021
//Summary: Controls what happens to player when a acron touch them and despawn the acorn also.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameStateController gameController;
    private bool isFalling;
    [SerializeField] private float timerForDespawn;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameStateController>();
        isFalling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFalling)
        {
            StartCoroutine(timeBeforeDespawn());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isFalling)
        {
            gameController.incrementOrDecrementAmmo(1);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player") && isFalling)
        {
            gameController.triggerPlayerSpawn(collision);
            gameController.incrementOrDecrementPlayerLives(-1);
        }
    }
    public void setIsFalling(bool a)
    {
        isFalling = a;
    }

    IEnumerator timeBeforeDespawn()
    {
        yield return new WaitForSeconds(timerForDespawn);
        Destroy( this.gameObject);
    }
}
