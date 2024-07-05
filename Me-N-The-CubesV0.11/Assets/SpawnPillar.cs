using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPillar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject swarmPrefab;
    private float spawninterval = 1f;
    public GameObject cubeSwarm;
    void Start()
    {
        cubeSwarm = GameObject.Find("CubeSwarm");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake(){
        InvokeRepeating("SpawnCube", 1, spawninterval);
    }
    void SpawnCube(){

        var newcube = Instantiate(swarmPrefab, transform.position + new Vector3(0,6,0), transform.rotation,cubeSwarm.transform);
        newcube.GetComponent<CubeGang>().isAlive = true;
        GameObject.Find("CubeCount").GetComponent<CubeListUpdator>().UpdateList();
    }
}
