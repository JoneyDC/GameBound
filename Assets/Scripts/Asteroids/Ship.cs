using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool Died;
    bool Hit;
    public AudioClip hitSound;

    public void Death()
    {
        if (!Hit)
        {
            Hit = true;
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
            GetComponent<AudioSource>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 12;
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<Animator>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 5;
            Died = true;
        }
    }
}
