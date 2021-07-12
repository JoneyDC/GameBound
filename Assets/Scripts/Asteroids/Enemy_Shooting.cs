using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public GameObject projecitle;
    public Transform Shotpoint;
    float timer, ShotSpeed;
    int Interval;
    public bool isShip;
    public GameObject Gun, Ship;
    public AudioClip shoot, death;
    private void Start()
    {
        ShotSpeed = 2;
    }

    private void Update()
    {
        if (Start_Asteroids.GameHasStarted)
        {
            timer += Time.deltaTime;
        }
        if(timer > ShotSpeed)
        {
            timer = 0;
            Fire();
            Interval += 1;   
        }
        if (!isShip)
        {
            if (Interval > 4)
            {
                ShotSpeed = 1f;
            }
            if (Interval > 10)
            {
                ShotSpeed = 0.8f;
            }
            if (Interval > 20)
            {
                ShotSpeed = 0.6f;
            }
            if (Interval > 30)
            {
                ShotSpeed = 0.4f;
            }
            if (Interval > 50)
            {
                ShotSpeed = 0.2f;
            }
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Start_Asteroids.GameHasStarted)
        {
            transform.right = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        }
    }
    void Fire()
    {
        Instantiate(projecitle, Shotpoint.position, Shotpoint.rotation);
        AudioSource.PlayClipAtPoint(shoot, transform.position);
    }
    public void Death()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().enabled)
        {
            AudioSource.PlayClipAtPoint(death, transform.position);
            LifeSystem.Score += 1000;
            Gun.SetActive(true);
            Ship.SetActive(true);
            Destroy(gameObject);
        }
    }
}
