using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_color : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.R))
            obj.GetComponent<Renderer>().material.color = Color.red;
        else if (Input.GetKeyUp(KeyCode.G))
            obj.GetComponent<Renderer>().material.color = Color.green;
        else if (Input.GetKeyUp(KeyCode.B))
            obj.GetComponent<Renderer>().material.color = Color.blue;
        else if (Input.GetKeyUp(KeyCode.Y))
            obj.GetComponent<Renderer>().material.color = Color.yellow;
        else if (Input.GetKeyUp(KeyCode.H))
            obj.GetComponent<Renderer>().material.color = Color.grey;
        else if (Input.GetKeyUp(KeyCode.T))
            obj.GetComponent<Renderer>().material.color = Color.black;
	}
}
