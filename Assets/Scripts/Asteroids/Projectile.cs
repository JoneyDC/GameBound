using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.right /5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            collision.gameObject.GetComponent<Aestroid_Move>().Hit();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LifeSystem>().LoseLife();
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
