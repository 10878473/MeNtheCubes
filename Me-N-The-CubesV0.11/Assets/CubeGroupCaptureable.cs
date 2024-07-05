using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGroupCaptureable : MonoBehaviour
{
    // Start is called before the first frame update
    public CubeListUpdator CubeListUpdator;
    public int pilesize;
    public Vector3 area;
    public GameObject cube;
    public List<GameObject>cubesInPile; 
    public GameObject cubeSwarm;
    void Start()
    {
        CubeListUpdator = GameObject.Find("CubeCount").GetComponent<CubeListUpdator>();
        cubeSwarm = GameObject.Find("CubeSwarm");

        
        for (int i = 0; i < pilesize; i++)
        {   
            var newcube = Instantiate(cube, PointInArea(), cube.transform.rotation, cubeSwarm.transform);
            newcube.GetComponent<CubeGang>().isAlive = false;
            cubesInPile.Add(newcube);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 PointInArea(){
        
        return transform.position + new Vector3(Random.Range(-area.x,area.x), Random.Range(1, area.y), Random.Range(-area.z,area.z));
    }
    
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < cubesInPile.Count; i++)
            {
                StartCoroutine("JumpDelay", cubesInPile[i]);
                
                
            }
            StartCoroutine("DestroyAfterX", 8);
        }

    }
    IEnumerator JumpDelay(GameObject cubetojump){
        //makes each cube in pile active, then jump for joy
        yield return new WaitForSecondsRealtime(Random.Range(0,1f));
        cubetojump.GetComponent<CubeGang>().isAlive = true;
        CubeListUpdator.UpdateList();
        cubetojump.GetComponent<Rigidbody>().AddForce(Vector3.up *9, ForceMode.Impulse);
    }
    IEnumerator DestroyAfterX(float x){
        yield return new WaitForSecondsRealtime(x);
        Destroy(gameObject);
    }
    
}
