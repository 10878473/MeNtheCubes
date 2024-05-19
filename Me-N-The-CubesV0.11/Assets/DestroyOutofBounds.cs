using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 500)
        {
            Debug.Log(gameObject.name + " out of bounds at position " + transform.position.ToString());
            Destroy(gameObject);
        }
    }
}
