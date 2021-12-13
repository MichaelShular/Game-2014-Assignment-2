using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsUIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas pauseCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void UnpauseAndPauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
        }

    }

}
