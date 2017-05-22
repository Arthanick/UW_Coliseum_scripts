using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spire_script : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (name == "throwed_spire")
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
            Destroy(this.gameObject, 2f);
        }
    }
    void OnCollisionEnter (Collision other)
    {
        if (name == "throwed_spire")
        {
            Debug.Log(other.gameObject.name);
            Destroy(this.gameObject);
        }
        else
            Debug.Log(other.gameObject.name);
    }
}
