using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJumpCollisionDetection : MonoBehaviour
{
    public CameraController canjumpscript;
    public bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        canjumpscript = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        canjumpscript.canjump = true;
        canJump = true;

    }
    private void OnCollisionExit(Collision collision){
        canjumpscript.canjump = false;
        canJump = false;
    }
}
