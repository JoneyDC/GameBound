using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    { 
        if (Input.GetAxisRaw("Horizontal") > 0 && Camera.main.WorldToScreenPoint(target.position).x > Screen.width/2)
        {
            transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
        }
    }
}
