using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaunchPadScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public Vector3 launchto;
    public float launchDist;
    public float launchspeed;
    private bool launching;
    private Vector3 startPos;
    //private Vector3 endPos;
    //private Vector3 heading;
    public Rigidbody rb;
    private bool reset;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        reset = true;
        startPos = transform.position;
        //endPos = transform.position + launchto;
        launchDist = transform.position.y + launchDist;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("Position - " + transform.position + "dist : " + launchDist + "islaunching : " + launching + "reset: " + reset);
        if (transform.position.y < launchDist && reset && launching)
        {
            //Debug.Log(gameObject.name + " Is launching!");

            rb.AddForce(Vector3.up*launchspeed, ForceMode.VelocityChange);
        }
        else if( transform.position.y > launchDist && reset){
            reset = false;
            rb.velocity = Vector3.zero;
            //Debug.Log(gameObject.name + " Has stopped at peak!");

        }
        else if(reset == false && Vector3.Distance(transform.position, startPos) < 2){
            reset = true;
            rb.velocity = Vector3.zero;
            //Debug.Log(gameObject.name + " Has reset!");
        }
    }
    public void Launch(){
        
        launching = true;
        
    }
    public void StopLaunch(){
        launching = false;
    }
}
