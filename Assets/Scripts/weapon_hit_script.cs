using UnityEngine;
using System.Collections;

public class weapon_hit_script : MonoBehaviour 
{
	void Start()
	{

	}

	void Update()
	{

	}

	void OnCollisionEnter (Collision other)
	{
		Debug.Log (other.gameObject.name); // Когда встречаемся с объектом то выводим об этом сообщение
	}
}
