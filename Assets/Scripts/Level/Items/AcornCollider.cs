//Michael Shular 101273089
//AcornCollider
//12/12/2021
//Summary: Sets a bool for acorn trigger to know when acorn stopped falling.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornCollider : MonoBehaviour
{
    [SerializeField] private LayerMask platform;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponentInParent<AcornController>().setIsFalling(false);
    }
}
