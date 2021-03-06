//Michael Shular 101273089
//PlayerBullet
//12/13/2021
//Summary: Controls how bullet will move, its collision and despawn.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction = Vector3.zero;
    [SerializeField] private float timer;
    private SFXController sfx;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXController>();
        }
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
            sfx.PlaySFX(SFXID.Stun);
            collision.GetComponent<SquirrelController>().gotStunned();
        }
        else
        {
            sfx.PlaySFX(SFXID.ProjectileHit);
        }
        Destroy(this.gameObject);
    }
}
