using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAbilities : MonoBehaviour
{
    public bool swarming;
    public bool forcing;
    // Start is called before the first frame update
    void Start()
    {
        swarming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            Debug.Log("Swarming!");
            swarming = true;
            //rb.AddForce(heading*9, ForceMode.Acceleration);
        }else if(Input.GetKey("q") == false) { swarming = false;}
        if (Input.GetKey(KeyCode.E))
        {
            forcing= true;
            Debug.Log("Forcing!");
            //rb.AddForce(cam.transform.forward*6, ForceMode.Acceleration);
        }
        else {forcing = false;}
    }
}
