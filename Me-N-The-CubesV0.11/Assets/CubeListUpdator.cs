using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CubeListUpdator : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text text;
    public int cubeList;
    public GameObject cubeSwarm;
    void Start()
    {
        cubeList = 0;
        cubeSwarm = GameObject.Find("CubeSwarm");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateList(){
        cubeList ++;
        text.text = "Cubes: " + cubeList.ToString();
    }
}
