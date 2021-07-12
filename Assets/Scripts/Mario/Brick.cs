using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    int Hits;
    public GameObject ParticleEffect;

    public void GetHit()
    {
        Hits += 1;
        if(Hits ==3)
        {
            ParticleEffect.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
