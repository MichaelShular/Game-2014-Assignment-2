//Michael Shular 101273089
//CrankController
//12/12/2021
//Summary: Controls the what happens when a player can trigger a growing platform

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            collision.GetComponent<PlayerController>().isTouchingCrank = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerController>().pushedCrank)
            {
                GetComponentInParent<GrowingPlatformController>().isGrowing = false;
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().isTouchingCrank = false;
        }
    }
}
