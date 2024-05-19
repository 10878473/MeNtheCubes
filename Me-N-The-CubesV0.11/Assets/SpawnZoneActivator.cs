using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneActivator : MonoBehaviour
{
    public GameObject spawnPillar;
    // Start is called before the first frame update
    void Start()
    {
        spawnPillar = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player"))
        {
            spawnPillar.SetActive(true);
            
        }
    }
}
