using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomDeathCollider : MonoBehaviour
{
    public static int Multiplyer;
    public AudioClip death;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.up * 12;
            LifeSystem.Score += 100 * Multiplyer;
            MushroomDeathCollider.Multiplyer += 1;
            Die();
        }
    }
    public void Die()
    {
        StartCoroutine("Dying");
    }
    IEnumerator Dying()
    {
        GetComponentInParent<Enemy_AI>().RemoveBoxCollider();
        GetComponentInParent<Enemy_AI>().enabled = false;
        AudioSource.PlayClipAtPoint(death, transform.position);
        GetComponentInParent<Rigidbody2D>().gravityScale = 5;
        GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * 10;
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }
}
