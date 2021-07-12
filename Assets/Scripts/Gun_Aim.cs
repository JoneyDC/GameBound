using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Aim : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;
    }
}
