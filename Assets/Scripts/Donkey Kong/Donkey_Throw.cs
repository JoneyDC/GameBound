using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donkey_Throw : MonoBehaviour
{
    public GameObject Barell;
    public Transform ShotPoint;
    float timer, ShotSpeed;
    int Interval;
    int Hits;
    public AudioClip tThrow;
    private void Start()
    {
        ShotSpeed = 4f;
        timer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Start_Donkey.GameStarted)
        {
            timer += Time.deltaTime;
        }
        if (timer > ShotSpeed)
        {
            timer = 0;
            Fire();
            Interval += 1;
        }

        if (Interval > 3)
        {
            ShotSpeed = 3f;
        }
        if (Interval > 8)
        {
            ShotSpeed = 2f;
        }
        if (Interval > 13)
        {
            ShotSpeed = 1f;
        }
        if (Interval > 20)
        {
            ShotSpeed = 0.8f;
        }
    }
    void Fire()
    {
        GameObject barell = Instantiate(Barell, ShotPoint.position, Quaternion.identity);
        barell.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * 200);
        AudioSource.PlayClipAtPoint(tThrow, transform.position);
    }
    public void Hit()
    {
        Hits += 1;
        if(Hits ==5)
        {
            Destroy(gameObject);
        }
    }
}
