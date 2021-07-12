using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject Joint1, Joint2;
    private void Update()
    {
        if(Joint1 == null && Joint2 == null)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

}
