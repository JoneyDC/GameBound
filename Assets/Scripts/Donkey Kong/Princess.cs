using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{
    public GameObject LoadingScreen, kiss;
    public AudioClip Kiss, Wingame;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("EndGame");
        }
    }
    IEnumerator EndGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        AudioSource.PlayClipAtPoint(Kiss, transform.position);
        kiss.SetActive(true);
        yield return new WaitForSeconds(1f);
        AudioSource.PlayClipAtPoint(Wingame, transform.position);
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("EndScene");
    }
}
