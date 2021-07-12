using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Donkey : MonoBehaviour
{
    public static bool GameStarted;
    public GameObject player;
    public AudioClip LandSound, ShipIn,ShipOut;
    void Start()
    {
        StartCoroutine("startGame");
    }
    IEnumerator startGame()
    {
        GameStarted = false;
        AudioSource.PlayClipAtPoint(ShipIn, Camera.main.transform.position);
        yield return new WaitForSeconds(1.5f);
        player.SetActive(true);
        AudioSource.PlayClipAtPoint(LandSound, Camera.main.transform.position);
        yield return new WaitForSeconds(0.5f);
        AudioSource.PlayClipAtPoint(ShipOut, Camera.main.transform.position);
        yield return new WaitForSeconds(1f);
        player.GetComponent<Player_Controller>().enabled = true;
        GameStarted = true;
    }
}
