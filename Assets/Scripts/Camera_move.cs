using UnityEngine;
using System.Collections;

public class Camera_move : MonoBehaviour 
{

	private Camera Cam;
	[SerializeField]
	private float speed = 4f;
	// Начальная инициализация
	void Start () 
	{
		Cam =  GetComponent <Camera> ();
	}
	
	// Обновление каждый фрейм
	void Update () 
	{
		if (Input.GetKey(KeyCode.LeftArrow))
			Cam.transform.Translate(Vector3.left * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow))
			Cam.transform.Translate (Vector3.right * speed * Time.deltaTime);
		if (Input.GetKey(KeyCode.UpArrow))
			Cam.transform.Translate(Vector3.up * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.DownArrow))
			Cam.transform.Translate (Vector3.down * speed * Time.deltaTime);
	}
}
