using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private Canvas instructionsUI; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void openInstructions()
    {
        instructionsUI.enabled = !instructionsUI;
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
