using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwapper : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject cineMachine;
    private bool cameratwodee;
    public GameObject player;
    public CameraController CameraController;
    public CanJumpCollisionDetection canJumpCollisionDetection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    void FixedUpdate(){
        if (cameratwodee)
        {
            mainCam.transform.position = player.transform.position + new Vector3(0,5,-50);
            mainCam.GetComponent<Camera>().orthographic = true;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            //player input- The z force should be nullified by the constraints, but also could delete vertical input
            Vector3 inputDir = mainCam.transform.forward*verticalInput + transform.right * horizontalInput;
            //take input direction based off of where you are looking and input
            if (inputDir != Vector3.zero ){
                    player.GetComponent<Rigidbody>().AddForce(inputDir*10, ForceMode.Acceleration);        
                } //adds force to the rigidbody of the player to get it to move. 

            player.GetComponent<Rigidbody>().velocity += Vector3.down * 9.81f * Time.deltaTime;

            if (Input.GetAxis("Jump") > 0 && canJumpCollisionDetection.canJump)
                {
                    player.GetComponent<Rigidbody>().AddForce(Vector3.up*7.5f, ForceMode.Impulse);
                    canJumpCollisionDetection.canJump = false;
                    Debug.Log("Did this code run once?");
                }
        }
    }


    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered 2d zone, changing cameras");
            cineMachine.SetActive(false);
            cameratwodee = true;
            
            mainCam.transform.eulerAngles = new Vector3(0,0,0);//Sets camera forward 
            mainCam.GetComponent<Camera>().orthographic = true;
            mainCam.GetComponent<Camera>().orthographicSize = 30;
            //Constrain the player so they cannot move in the z direction, and only rotate in the z direction - should look like a 2d game.
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);// sets player onto z path where 2d geometry is
            player.transform.eulerAngles = new Vector3(0,0,transform.rotation.z);// should reset the x and y rotation
            
        }
    }
    void OnTriggerExit(Collider other){
        if (other.CompareTag("Player"))
                {
                    Debug.Log("Player exit 2d zone,---- changing cameras");
                    cineMachine.SetActive(true);
                    cameratwodee = false;
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    mainCam.GetComponent<Camera>().orthographic = false;
                }
        }
}
