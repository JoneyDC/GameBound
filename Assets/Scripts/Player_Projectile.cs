using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Projectile : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.right/2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ship"))
        {
            collision.gameObject.GetComponent<Ship>().Death();
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Donkey"))
        {
            collision.gameObject.GetComponent<Donkey_Throw>().Hit();
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Barell"))
        {
            Destroy(collision.gameObject);
            LifeSystem.Score += 200;
            Destroy(gameObject);
        }
    }
}
