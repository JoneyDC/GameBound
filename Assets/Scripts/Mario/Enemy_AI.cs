using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    Rigidbody2D rb;
    bool movingRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingRight)
        {
            rb.velocity = -transform.right * 2;
        }
        else
        {
            rb.velocity = transform.right * 2;
        }
    }
    public void SwitchDirection()
    {
        if(movingRight)
        {
            movingRight = false;
        }
        else
        {
            movingRight = true;
        }
    }
    public void RemoveBoxCollider()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
    }

}
