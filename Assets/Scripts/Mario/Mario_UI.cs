using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mario_UI : MonoBehaviour
{
    public Text score;
    public Text coin;
    public Text time;
    public Text lives;

    [HideInInspector] public int  coinAmount;
    float StartTime;
    void Start()
    {
        StartTime = 350;
    }

    // Update is called once per frame
    void Update()
    {
        StartTime -= Time.deltaTime;
        if(StartTime <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<LifeSystem>().LoseLife();
        }

        time.text = StartTime.ToString("F0");
        coin.text = "x" + coinAmount.ToString();
        score.text = LifeSystem.Score.ToString("D6");
        lives.text = "x" + LifeSystem.lives.ToString();
    }
}
