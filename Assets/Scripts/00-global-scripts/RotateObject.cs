using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public Vector3 rotateDirection;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.Rotate(Vector3.left * Time.deltaTime, Space.Self);
        gameObject.transform.Rotate(rotateDirection * Time.deltaTime*2, Space.World);


    }
}

   