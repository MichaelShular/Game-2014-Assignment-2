using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornCollider : MonoBehaviour
{
    [SerializeField] private LayerMask platform;
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

        Debug.Log("Grounded");
        GetComponentInParent<AcornController>().setIsFalling(false);

    }
}
