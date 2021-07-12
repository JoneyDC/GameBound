using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    int hitAmount;
    public GameObject Portal, ParticleSystem;

    public void HitDoor()
    {
        hitAmount += 1;
        if(hitAmount == 3)
        {
            Portal.SetActive(true);
            Portal.GetComponent<Animator>().SetTrigger("OpenPortal");
            ParticleSystem.SetActive(true);
            Destroy(gameObject);
        }
    }
}
