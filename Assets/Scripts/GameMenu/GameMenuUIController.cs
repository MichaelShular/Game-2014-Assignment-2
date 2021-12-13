//Michael Shular 101273089
//GameMenuUIController
//12/12/2021
//Summary: Controls the buttons UI in the gamemenu scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenuUIController : MonoBehaviour
{
    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void levelOne()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }
}
