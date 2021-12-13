//Michael Shular 101273089
//CheckPointController
//12/12/2021
//Summary: Controls what check point a player will spawn at.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckPointController : MonoBehaviour
{
    [SerializeField] private Transform newSpawnPoint;
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
            gameController.updatePlayerSpawnpoint(newSpawnPoint);
        }
    }
}
