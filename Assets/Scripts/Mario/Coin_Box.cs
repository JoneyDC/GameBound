using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Box : MonoBehaviour
{
    public float CoinAmount;
    public GameObject Coin;
    public AudioClip coinGain;

    float Timer;


    // Update is called once per frame
    void Update()
    {
        if(CoinAmount == 0)
        {
            GetComponentInParent<SpriteRenderer>().color = Color.grey;
        }
        Timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && CoinAmount > 0 && Timer > 0.2f)
        {
            TriggerCoin();
            GetComponentInParent<Animator>().SetTrigger("Pop");
            Timer = 0;
        }
    }
    public void TriggerCoin()
    {
        if(CoinAmount > 0)
        {
            StartCoroutine("CoinBounce");
            CoinAmount -= 1;
        }
    }
    IEnumerator CoinBounce()
    {
        AudioSource.PlayClipAtPoint(coinGain, transform.position);
        GameObject coin = Instantiate(Coin, transform.position + new Vector3(0,2f), Quaternion.identity);
        coin.GetComponent<Animator>().SetTrigger("Bounce");
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Mario_UI>().coinAmount += 1;
        LifeSystem.Score += 200;
        Destroy(coin);
    }
}
