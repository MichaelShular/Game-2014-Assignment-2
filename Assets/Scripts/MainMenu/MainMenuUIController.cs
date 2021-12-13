//Michael Shular 101273089
//MainMenuUIController
//12/12/2021
//Summary: Controls menu buttons

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private Canvas instructionsUI; 
   
    public void changeToGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void openInstructions()
    {
        instructionsUI.enabled = !instructionsUI.enabled;
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
