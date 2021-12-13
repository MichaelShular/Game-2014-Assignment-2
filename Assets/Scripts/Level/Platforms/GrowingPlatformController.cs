//Michael Shular 101273089
//GrowingPlatformContoller
//12/12/2021
//Summary: Controls what how much the platform will grow, speed of movement, and spawns the vines.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GrowingPlatformController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform growLocation;
    private Vector3 targetLocation;
    public bool isGrowing;
    [SerializeField] private float speed;

    [Header("VineGrowing")]
    [SerializeField] private GameObject vineTop;
    [SerializeField] private GameObject vineBottom;
    [SerializeField] private List<Transform> initialVineSpawnLocation;
    private Vector3 currentVineSpawn;
    private Vector3 currentVineSpawnTwo;

    // Start is called before the first frame update
    void Start()
    {
        targetLocation = growLocation.transform.position;
        isGrowing = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isGrowing)
        {
            StartCoroutine(grow());
        }
    }
    IEnumerator grow()
    {
        int amountOfVineSpawns = Mathf.RoundToInt(Vector3.Distance(targetLocation, transform.position));
        //Where the vines start to spawn
        currentVineSpawn = initialVineSpawnLocation[0].position;
        currentVineSpawnTwo = initialVineSpawnLocation[1].position;

        //Vine 1
        for (int i =0 ; i < amountOfVineSpawns; i++)
        {
            if (i % 2 == 0)
            {
                GameObject temp = Instantiate(vineTop, transform);
                temp.transform.position = currentVineSpawn;
                currentVineSpawn += Vector3.down;
            }
            else
            {
                GameObject temp = Instantiate(vineBottom, transform);
                temp.transform.position = currentVineSpawn;
                currentVineSpawn += Vector3.down;
            }
        }
        //Vine 2
        for (int i = 0; i < amountOfVineSpawns; i++)
        {
            if (i % 2 == 0)
            {
                GameObject temp = Instantiate(vineTop, transform);
                temp.transform.position = currentVineSpawnTwo;
                currentVineSpawnTwo += Vector3.down;
            }
            else
            {
                GameObject temp = Instantiate(vineBottom, transform);
                temp.transform.position = currentVineSpawnTwo;
                currentVineSpawnTwo += Vector3.down;
            }
        }
        
        while ((targetLocation - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
            yield return null;
        }
        isGrowing = false;
    }
}
