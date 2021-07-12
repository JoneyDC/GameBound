using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject LoadingScreen;
    public AudioClip EnterPortal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("NextLevel");
        }
    }
    IEnumerator NextLevel()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //Play animation
        AudioSource.PlayClipAtPoint(EnterPortal, transform.position);
        yield return new WaitForSeconds(2f);
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Asteroids");
    }
}
