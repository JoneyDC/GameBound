using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aestroid_Move : MonoBehaviour
{
    public Vector2 Direction;
    public float Force;
    public GameObject AestroidPrefab;
    public bool Biggest, Smallest;
    bool TriggerOnce;
    public AudioClip AsteroidDeath;

    // Update is called once per frame

    private void Update()
    {
        if(Start_Asteroids.GameHasStarted)
        {
            if(!TriggerOnce)
            {
                TriggerOnce = true;
                if (Biggest)
                {
                    GetComponent<Rigidbody2D>().AddForce(Direction * Force, ForceMode2D.Impulse);
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100, 101) * Force / 100, Random.Range(-100, 101) * Force / 100), ForceMode2D.Impulse);
                }
            }
        }
    }
    public void Hit()
    {
        if (!Smallest)
        {
            Instantiate(AestroidPrefab, transform.position, Quaternion.identity);
            Instantiate(AestroidPrefab, transform.position, Quaternion.identity);
        }
        AudioSource.PlayClipAtPoint(AsteroidDeath, transform.position, 0.4f);
        LifeSystem.Score += 200;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy_Shooting>().Death();
        }
    }
}
