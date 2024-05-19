using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPillar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject swarmPrefab;
    private float spawninterval = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake(){
        InvokeRepeating("SpawnCube", 1, spawninterval);
    }
    void SpawnCube(){

        var newcube = Instantiate(swarmPrefab, transform.position + new Vector3(0,6,0), transform.rotation);
        newcube.GetComponent<CubeGang>().isAlive = true;
    }
}
