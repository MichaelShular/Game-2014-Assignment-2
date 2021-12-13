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
    [SerializeField] private TextMeshProUGUI amountOfLives;
    [SerializeField] private TextMeshProUGUI amountOfAmmoUI;
    private int amountOfAmmo;

    [Header("Player Spawns")]
    [SerializeField] private Transform startSpawn;
    private Transform currentSpawn;

    [Header("Eagle Spawn")]
    [SerializeField] private GameObject eagle;
    private GameObject player;
    [SerializeField] private float minSpawnEagleTimer;
    [SerializeField] private float maxSpawnEagleTimer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentSpawn = startSpawn;
        player = GameObject.Find("Player");
        StartCoroutine(spawnEagel());
        amountOfLives.text = numberOfPlayerLifes.ToString();
        amountOfAmmo = 0;
        updateAmmoUI(amountOfAmmo.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfPlayerLifes <= 0)
        {
            endGame("You Lost");
        }
    }
    public void incrementOrDecrementPlayerLives(int amount)
    {
        numberOfPlayerLifes += amount;
        amountOfLives.text = numberOfPlayerLifes.ToString();
    }

    public void triggerPlayerSpawn(Collider2D collision)
    {
        collision.transform.position = currentSpawn.position;
    }

    public void updatePlayerSpawnpoint(Transform updatedPoint)
    {
        currentSpawn = updatedPoint;
    }

    IEnumerator spawnEagel()
    {
        yield return new WaitForSeconds(randomTimerForEagel());
        GameObject temp = Instantiate(eagle);
        temp.transform.position = new Vector3(player.transform.position.x + 4, player.transform.position.y + 4, 0.0f); 
        StartCoroutine(spawnEagel());
    }

    private float randomTimerForEagel()
    {
        return Random.Range(minSpawnEagleTimer, maxSpawnEagleTimer);
    }

    public void endGame(string endGameText)
    {
        Time.timeScale = 0;
        gameStateCanvas.enabled = true;
        winOrLoseText.text = endGameText;
    }

    public void incrementOrDecrementAmmo(int amount)
    {
        amountOfAmmo += amount;
        updateAmmoUI(amountOfAmmo.ToString());
    }
    public void updateAmmoUI(string text)
    {
        amountOfAmmoUI.text = text;
    }
}
