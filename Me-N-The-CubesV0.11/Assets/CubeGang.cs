using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeGang : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject targetPlayer;
    private float distToPlayer;
    public Vector3 heading;
    public GameObject cam;
    public InputAbilities InputAbilities;
    private float speed = 10f;
    public bool isAlive;
    public Color originalColor;
    public Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        InputAbilities = GameObject.Find("Player").GetComponent<InputAbilities>();
        cam = GameObject.Find("Main Camera");

        rb = gameObject.GetComponent<Rigidbody>();
        targetPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {             
        
        heading = (targetPlayer.transform.position - transform.position).normalized;

        distToPlayer = Vector3.Distance(transform.position, targetPlayer.transform.position);
        if( isAlive && (distToPlayer > 15) && InputAbilities.swarming == false && InputAbilities.forcing == false){
            rb.AddForce(heading * speed, ForceMode.Acceleration);

        }
        if ((InputAbilities.swarming == true) && (distToPlayer > 4) && isAlive && !InputAbilities.forcing)
        {
            //Debug.Log("REALLY SWARMING");
            rb.AddForce(heading*(speed*1.5f), ForceMode.Acceleration);

        }
        if (InputAbilities.forcing && isAlive && !InputAbilities.swarming)
        {
            //rb.AddForce(heading*9, ForceMode.Acceleration);
            rb.AddForce(cam.transform.forward*(speed*1.8f), ForceMode.Acceleration);
        }
        if(rb.velocity.magnitude < 1 && isAlive && (distToPlayer > 20) && !InputAbilities.forcing && !InputAbilities.swarming){
            rb.AddForce(Vector3.up*4, ForceMode.Impulse);
            gameObject.GetComponent<Renderer>().material.color = newColor;
        } else{gameObject.GetComponent<Renderer>().material.color = originalColor;}
    }
}
