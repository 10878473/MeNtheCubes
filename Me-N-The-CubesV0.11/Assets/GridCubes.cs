using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cubeinspace {
    private int positionX;
    private int positionY;
    //public newCube(positionX,positionY){
      //  this.positionX = positionX;
        //this.positionY = positionY;

//    }
}

public class GridCubes : MonoBehaviour
{

    public List<GameObject> cubes;
    public GameObject gridCube;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate a grid, 20x20 of 2x2 cubes 2 units apart. 
        GenerateGrid(30,30);

        for (int i = 0; i < cubes.Count; i++)
        {
            Color randcolor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            cubes[i].transform.Translate(new Vector3(0,Random.Range(0,2f), 0 ));
            cubes[i].GetComponent<Renderer>().material.color = randcolor;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid(int sizeX, int sizeZ){
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                
                cubes.Add(Instantiate(gridCube, new Vector3(x*2, 0f, z*2), gridCube.transform.rotation));
            }
            
        }
            
    }
}
