using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DestructiblePlatformControler : MonoBehaviour
{
    [SerializeField] private float timeBeforeRemoveFromScene;
    [SerializeField] private float timeBeforeRespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
