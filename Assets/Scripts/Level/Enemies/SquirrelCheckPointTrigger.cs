using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelCheckPointTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 jumpForceAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Squirrel"))
        {
            collision.GetComponent<SquirrelController>().jumpForce(jumpForceAmount);
        }
    }
}
