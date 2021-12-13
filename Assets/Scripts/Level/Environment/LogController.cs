//Michael Shular 101273089
//LogController
//12/12/2021
//Summary: Controls the what happens during a trigger enter with the squirrel  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Squirrel"))
        {
            collision.GetComponent<SquirrelController>().gotStunned();
        }
    }
}
