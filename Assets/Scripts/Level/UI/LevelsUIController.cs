//Michael Shular 101273089
//LevelsUIController
//12/12/2021
//Summary: Controls the ui button function in the level scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsUIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas pauseCanvas;
    private SFXController sfx;

    private void Start()
    {
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXController>();
        }
    }
    public void loadGameMenu()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("GameMenu");
    }
    public void UnpauseAndPauseGame()
    {
        sfx.PlaySFX(SFXID.UIClick);
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
