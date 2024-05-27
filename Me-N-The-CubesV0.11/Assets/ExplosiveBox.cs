using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBox : MonoBehaviour
{
    
    public float expForce, radius; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player") || other.CompareTag("CubeGang"))
        {
            StartCoroutine("ExplosionTimer");
        }
    }
    IEnumerator ExplosionTimer(){
        for (int i = 0; i < 5; i++)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            yield return new WaitForSeconds(.25f);
            Debug.Log("Bomb Timer -  " + i);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(.25f);
            
        }
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders){
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null){
                rb.GetComponent<Rigidbody>().AddExplosionForce(expForce,transform.position, radius);

            }
        }
        Destroy(gameObject);
        
    }
}
