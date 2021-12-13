//Michael Shular 101273089
//EagleController
//12/12/2021
//Summary: Control aspects of the enemy eagle. Such as movement and when to drop an acorn

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [Range(-1, 1)]
    [SerializeField] private int direction;

    [Header("Despawn")]
    [SerializeField] private float despawnTimer;

    [Header("Acorn Drop")]
    [SerializeField] GameObject acorn;
    private GameObject player;
    private bool hasDroppedAcorn;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hasDroppedAcorn = false;
        StartCoroutine(timeBeforeDespawn());
    }

    // Update is called once per frame

    private void Update()
    {
        if (!hasDroppedAcorn && player.transform.position.x + 0.5 > transform.position.x && player.transform.position.x - 0.5 < transform.position.x)
        {
            hasDroppedAcorn = true;
            GameObject temp = Instantiate(acorn);
            temp.transform.position = transform.position;
        }     
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(speed * direction, 0.0f, 0.0f);
    }
    IEnumerator timeBeforeDespawn()
    {
        yield return new WaitForSeconds(despawnTimer);
        Destroy(this.gameObject);
    }
}
