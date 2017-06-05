using UnityEngine;
using System.Collections;

public class Camera_move : MonoBehaviour 
{
	[SerializeField]
	private float speed = 4f;
	private Camera Cam;
	private RaycastHit hit;

	public GameObject Dummy_prefab;
	public GameObject Player;

	private GameObject current_creation;
	// Начальная инициализация
	void Start () 
	{
		Cam =  GetComponent <Camera> ();
	}
	
	// Обновление каждый фрейм
	void FixedUpdate () 
	{
		if (Input.GetKey (KeyCode.LeftArrow))
			Cam.transform.Translate(Vector3.left * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow))
			Cam.transform.Translate (Vector3.right * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.UpArrow))
			Cam.transform.Translate(new Vector3(0,1,1) * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.DownArrow))
			Cam.transform.Translate (new Vector3(0, -1, -1) * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.LeftControl) && Input.GetMouseButtonDown(0)) 
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
			{
				current_creation = Instantiate (Dummy_prefab, hit.point, Quaternion.identity) as GameObject;
			}
		}
	}
}
