using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_check : MonoBehaviour {
    private int Health = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Health == 0)
        {
            Destroy(this.gameObject);
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "throwed_spire")
        {
            Debug.Log(other.gameObject.name);
            Health--;
            Debug.Log("Current health is: " + Health);
        }
        if (other.gameObject.name == "Weapon")
            Destroy(this.gameObject);
    }
}
