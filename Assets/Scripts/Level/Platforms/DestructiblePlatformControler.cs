//Michael Shular 101273089
//DestructiblePlatformController
//12/12/2021
//Summary: Controls the despawning and respawing of the platform.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DestructiblePlatformControler : MonoBehaviour
{
    [SerializeField] private float timeBeforeRemoveFromScene;
    [SerializeField] private float timeBeforeRespawn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(TimerForDestoryingObject());
    }

    IEnumerator TimerForDestoryingObject()
    {
        yield return new WaitForSeconds(timeBeforeRemoveFromScene);
        GetComponent<BoxCollider2D>().enabled = false;
        List<SpriteRenderer> tileSpritesRen = GetComponentsInChildren<SpriteRenderer>().ToList();
        foreach (var renderer in tileSpritesRen)
        {
            renderer.enabled = false;
        }
        StartCoroutine(TimerRespawningPlatform());
    }
    IEnumerator TimerRespawningPlatform()
    {
        yield return new WaitForSeconds(timeBeforeRespawn);
        GetComponent<BoxCollider2D>().enabled = true;
        List<SpriteRenderer> tileSpritesRen = GetComponentsInChildren<SpriteRenderer>().ToList();
        foreach (var renderer in tileSpritesRen)
        {
            renderer.enabled = true;
        }

    }
}
