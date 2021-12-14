//Michael Shular 101273089
//MainMenuUIController
//12/12/2021
//Summary: Controls menu buttons

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> instructionScripts;
    [SerializeField] private Canvas instructionsUI;
    private int currentInstuction;

    private void Start()
    {
        currentInstuction = 0;
        instructionScripts[currentInstuction].enabled = true;
    }
    public void changeToGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void openInstructions()
    {
        instructionsUI.enabled = !instructionsUI.enabled;
        currentInstuction = 0;
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void changeInstuctionText()
    {
        currentInstuction++;
        if(currentInstuction == instructionScripts.Count)
        {
            currentInstuction = 0;
        }

        if(currentInstuction == 0)
        {
            instructionScripts[currentInstuction].enabled = true;
            instructionScripts[instructionScripts.Count -1].enabled = false;
        }
        else
        {
            instructionScripts[currentInstuction].enabled = true;
            instructionScripts[currentInstuction - 1].enabled = false;
        }
        
    }
}
