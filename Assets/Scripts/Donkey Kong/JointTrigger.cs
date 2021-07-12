using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointTrigger : MonoBehaviour
{
    int Hits;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            //play Small Anim
            GetComponent<Animator>().SetTrigger("Flash");
            Hits += 1;
            if(Hits == 3)
            {
                Destroy(gameObject);
            }
        }
    }
}
