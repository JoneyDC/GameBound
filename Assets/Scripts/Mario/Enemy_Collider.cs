using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collider : MonoBehaviour
{
    LayerMask Ground;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<LifeSystem>().LoseLife();
        }
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            GetComponentInParent<Enemy_AI>().SwitchDirection();
        }
    }
}
