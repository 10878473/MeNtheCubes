using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Text debug;
    public GameObject player;
    public Rigidbody rb;
    
    public float speed;
    public bool canjump;//move to canjump script? and reference here?

    public List<Color> colors;
    
    public bool cameratwodee;
    
    // Start is called before the first frame update
    void Start()
    {
        
        speed = 20;
    }

    // Update is called once per frame
    void Update(){
        //some visual fun here        
        debug.text = "Canjump?"+canjump + "  Velocity = " + rb.velocity.magnitude;

        if (rb.velocity.magnitude < 20)
        {
            player.GetComponent<Renderer>().material.color = colors[0];
        }else if (rb.velocity.magnitude > 20 && rb.velocity.magnitude< 30)
        {
            player.GetComponent<Renderer>().material.color = colors[1];

        }else if (rb.velocity.magnitude > 30 && rb.velocity.magnitude< 40)
        {
            player.GetComponent<Renderer>().material.color = colors[2];

        }else if (rb.velocity.magnitude > 40)
        {
            player.GetComponent<Renderer>().material.color = colors[3];

        }

    }
    void FixedUpdate()//Fixed update vs Update - Should fix the frame rate/ monitor size changing physics problems
    {
        
        // take view direction- already taken care of by cinemachine
        //Vector3 viewDir = player.transform.position - new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        
        // 
        if (!cameratwodee)
        {
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            //Manual gravity tweaking - 9.81 constant of gravity, down for direction, 1.5 for tweak
            rb.velocity += Vector3.down * 1.5f * 9.81f * Time.deltaTime;

            Vector3 inputDir = transform.forward*verticalInput + transform.right * horizontalInput;
            //take input direction based off of where you are looking and input
            if (inputDir != Vector3.zero ){
                rb.AddForce(inputDir*speed, ForceMode.Acceleration);        
            } //adds force to the rigidbody of the player to get it to move. 
            if (Input.GetAxis("Jump") > 0 && canjump)
                {
                    
                    rb.AddForce(Vector3.up*20, ForceMode.Impulse);
                    canjump = false;
                    
                }
        
        }

    }
    void GroundCheck(){
        //throws a ray down 1 unit to see if there is anything below it 
        if (Physics.Raycast(player.transform.position, Vector3.down, 1.5f))
        {
            //canjump = true;
        }
    }
    
}
