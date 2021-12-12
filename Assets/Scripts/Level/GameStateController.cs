using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameStateController : MonoBehaviour
{
    [Header("Game State UI")]
    [SerializeField] private int numberOfPlayerLifes;
    [SerializeField] private Canvas gameStateCanvas;
    [SerializeField] private TextMeshProUGUI winOrLoseText;

    [Header("Player Spawns")]
    [SerializeField] private Transform startSpawn;
    private Transform currentSpawn;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentSpawn = startSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfPlayerLifes <= 0)
        {
            Time.timeScale = 0;
            gameStateCanvas.enabled = true;
            winOrLoseText.text = "You Lost"; 
        }
    }
    public void incrementOrDecrementPlayerLives(int amount)
    {
        numberOfPlayerLifes += amount;
    }

    public void triggerPlayerSpawn(Collider2D collision)
    {
        collision.transform.position = currentSpawn.position;
    }

    public void updatePlayerSpawnpoint(Transform updatedPoint)
    {
        currentSpawn = updatedPoint;
    }

}
