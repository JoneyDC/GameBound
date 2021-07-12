using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStoper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0, 0));
    }
}
