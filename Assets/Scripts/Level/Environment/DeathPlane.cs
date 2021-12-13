//Michael Shular 101273089
//DeathPlane
//12/12/2021
//Summary: If Player collides with the plane it will respawn the at the last checkpoint
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeathPlane : MonoBehaviour
{
    private GameStateController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameStateController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.triggerPlayerSpawn(collision);
            gameController.incrementOrDecrementPlayerLives(-1);
        }
    }
}
