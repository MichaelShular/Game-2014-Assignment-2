using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction = Vector3.zero;
    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
            Destroy(this.gameObject);
        transform.position += direction * speed * Time.deltaTime;
    }
    public void setDirection(Vector3 a)
    {
        direction = a;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Squirrel"))
        {
            collision.GetComponent<SquirrelController>().gotStunned();
        }
        Destroy(this.gameObject);
    }
}
