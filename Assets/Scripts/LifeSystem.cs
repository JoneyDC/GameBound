using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    public static int lives = 3;
    public static int Score;
    public AudioClip playerDeath;
    public GameObject YouLoseText;
    public void LoseLife()
    {
        lives -= 1;
        StartCoroutine("Death");
    }
    IEnumerator Death()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
        AudioSource.PlayClipAtPoint(playerDeath, Camera.main.transform.position, 0.5f);
        GetComponent<Player_Controller>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 5;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
        yield return new WaitForSeconds(2f);
        if (lives >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            lives = 0;
            YouLoseText.SetActive(true);
            yield return new WaitForSeconds(2f);
            Application.Quit();
        }
    }
}
