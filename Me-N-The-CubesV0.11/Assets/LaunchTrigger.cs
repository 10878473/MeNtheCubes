using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTrigger : MonoBehaviour
{
    public LaunchPadScript LaunchPadScript;
    // Start is called before the first frame update
    void Start()
    {
        LaunchPadScript = gameObject.GetComponentInParent<LaunchPadScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(){
        LaunchPadScript.Launch();
        Debug.Log("Should be launching somethin");
        //other.attachedRigidbody.AddForce(Vector3.up*100,ForceMode.Impulse);
    }
    void OnTriggerExit(Collider other){
        LaunchPadScript.StopLaunch();
        //other.attachedRigidbody.AddForce(Vector3.up*100,ForceMode.Impulse);
    }
}
