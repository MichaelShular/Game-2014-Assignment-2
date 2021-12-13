using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelCheckPointTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 jumpForceAmount;
    [Range(-1, 1)]
    [SerializeField] private int Direction;

    [SerializeField] private SquirrelState stateForTrigger;

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
        switch (stateForTrigger)
        {
            case SquirrelState.Flip:
                if (collision.CompareTag("Squirrel"))
                {
                    collision.GetComponent<SquirrelController>().Flip(Direction);
                }
                break;
            case SquirrelState.Jump:
                if (collision.CompareTag("Squirrel"))
                {
                    collision.GetComponent<SquirrelController>().jumpForce(jumpForceAmount);
                }
                break;
            default:
                break;
        }
        
    }

    public enum SquirrelState
    {
        Flip,
        Jump
    }

}
