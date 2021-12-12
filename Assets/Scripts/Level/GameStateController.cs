using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameStateController : MonoBehaviour
{
    [SerializeField] int numberOfPlayerLifes;
    [SerializeField] Canvas gameStateCanvas;
    [SerializeField] TextMeshProUGUI winOrLoseText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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

}
