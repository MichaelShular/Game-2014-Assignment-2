//Michael Shular 101273089
//MainMenuUIController
//12/13/2021
//Summary: Controls menu buttons and the navigation of instuctions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> instructionScripts;
    [SerializeField] private Canvas instructionsUI;
    [SerializeField] private Canvas settingsUI;
    private SFXController sfx;

    private int currentInstuction;

    private void Start()
    {
        currentInstuction = 0;
        instructionScripts[currentInstuction].enabled = true;
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXController>();
        }
    }
    public void changeToGameMenu()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("GameMenu");
    }

    public void openInstructions()
    {
        sfx.PlaySFX(SFXID.UIClick);
        instructionsUI.enabled = !instructionsUI.enabled;
        currentInstuction = 0;
    }

    public void openSettings()
    {
        sfx.PlaySFX(SFXID.UIClick);
        settingsUI.enabled = !settingsUI.enabled;
    }
    public void quitGame()
    {
        sfx.PlaySFX(SFXID.UIClick);
        Application.Quit();
    }

    public void changeInstuctionText()
    {
        sfx.PlaySFX(SFXID.UIClick);
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
    public void gameVolume(float size)
    {
        AudioListener.volume = size;
    }
}
