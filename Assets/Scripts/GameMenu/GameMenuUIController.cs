//Michael Shular 101273089
//GameMenuUIController
//12/13/2021
//Summary: Controls the buttons UI in the gamemenu scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenuUIController : MonoBehaviour
{
    private SFXController sfx;

    private void Start()
    {
        if (GameObject.Find("BMGManager") != null)
        {
            GameObject.Find("BMGManager").GetComponent<BGMController>().PlayTrack(TrackID.GameMenu);
        }
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXController>();
        }
    }
    public void backToMainMenu()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("MainMenu");
    }

    public void levelOne()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("Level_1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }
}
