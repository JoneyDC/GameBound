using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsUI : MonoBehaviour
{
    public Text score;
    public GameObject Life1, Life2, Life3;


    // Update is called once per frame
    void Update()
    {
        score.text = LifeSystem.Score.ToString("D4");
        if(LifeSystem.lives == 0)
        {
            Life1.SetActive(false);
            Life2.SetActive(false);
            Life3.SetActive(false);
        }
        if (LifeSystem.lives == 1)
        {
            Life1.SetActive(true);
            Life2.SetActive(false);
            Life3.SetActive(false);
        }
        if (LifeSystem.lives == 2)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(false);
        }
        if (LifeSystem.lives == 3)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
        }
    }
}
