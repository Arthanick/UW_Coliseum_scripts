using UnityEngine;
using System.Collections;

public class Camera_move : MonoBehaviour 
{

	private Camera Cam;
	[SerializeField]
	private float speed = 4f;
	// Use this for initialization
	void Start () 
	{
		Cam =  GetComponent <Camera> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.LeftArrow))
			Cam.transform.Translate(Vector3.left * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow))
			Cam.transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
