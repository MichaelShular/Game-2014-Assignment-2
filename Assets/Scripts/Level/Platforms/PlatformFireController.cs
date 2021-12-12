using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformFireController : MonoBehaviour
{
    [Header("Movement")]
    private Vector3 targetLocation;
    private Vector3 targetLocationChange;
    private bool isWalking;
    [SerializeField] private float speed;

    [Header("Check For next Move Location")]
    [SerializeField] private Transform checkLocation;
    [SerializeField] private LayerMask Platform;
    private Directions currentDirection;
    private bool changedSides;


    // Start is called before the first frame update
    void Start()
    {
        targetLocation = transform.position;
        targetLocationChange = Vector3.right;
        currentDirection = Directions.Right;
        changedSides = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWalking)
        {
            movement();
        }
    }

    private void movement()
    {
        if (PlatformBelowFire(checkLocation.position) || changedSides)
        {
            changedSides = false;
            StartCoroutine(MoveCheck());
        }
        else
        {
            switch (currentDirection)
            {
                case Directions.Up:
                    updateDirectionOfFire(Vector3.right, Directions.Right);

                    break;
                case Directions.Right:
                    updateDirectionOfFire(Vector3.down, Directions.Down);
                    break;
                case Directions.Down:
                    updateDirectionOfFire(Vector3.left, Directions.Left);
                    break;
                case Directions.Left:
                    updateDirectionOfFire(Vector3.up, Directions.Up);
                    break;
                default:
                    break;
            }
            changedSides = true;
        }
    }

    IEnumerator MoveCheck()
    {
        targetLocation += targetLocationChange;
        isWalking = true;
        while ((targetLocation - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
            yield return null;
        }
        isWalking = false;
    }
    private bool PlatformBelowFire(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 0.3f, Platform) != null)
        {
            return true;
        }
        return false;
    }
    private void updateDirectionOfFire(Vector3 newTargetLoctionChange, Directions setFiresNewDirection)
    {
        targetLocationChange = newTargetLoctionChange;
        currentDirection = setFiresNewDirection;
        transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
    }
    public enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }

}
