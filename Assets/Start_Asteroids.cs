using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Asteroids : MonoBehaviour
{
    public GameObject Player;
    public static bool GameHasStarted;
    public AudioClip OpenPortal, ExitPortal, ClosePortal;
    AudioSource auc;
    private void Awake()
    {
        auc = GetComponent<AudioSource>();
    }
    void Start()
    {
        GameHasStarted = false;
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        GetComponent<Animator>().SetTrigger("OpenPortal");
        auc.PlayOneShot(OpenPortal);
        yield return new WaitForSeconds(1f);
        auc.PlayOneShot(ExitPortal);
        Player.SetActive(true);
        //Play Animation
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().SetTrigger("ClosePortal");
        auc.PlayOneShot(ClosePortal);
        yield return new WaitForSeconds(1f);
        Player.GetComponent<Player_Controller>().enabled = true;
        GameHasStarted = true;
    }
}
