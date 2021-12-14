//Michael Shular 101273089
//GemController
//12/13/2021
//Summary: Controls gem collision.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    private GameStateController gameController;
    private SFXController sfx;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameStateController>();
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sfx.PlaySFX(SFXID.Stun);
            gameController.addedToTotalPoints(10);
            Destroy(this.gameObject);
        }
    }
}
