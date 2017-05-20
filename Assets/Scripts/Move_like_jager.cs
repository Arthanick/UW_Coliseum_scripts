using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_like_jager : MonoBehaviour 
{
	[SerializeField]
	float rotation_speed = 200f;

	private UnityEngine.AI.NavMeshAgent agent;
	private Animator weapon;
	private RaycastHit hit;
	private Vector3 Look_target = new Vector3();
	private Vector3 LastLook_target = new Vector3();
	private Vector3 dir;
	private float view_angle;
    private weapon_hit_script flyable;
    private GameObject create_throw;

    public GameObject current_weapon;

	void Start() 
	{
		weapon = GetComponent<Animator>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update() 
	{
		if (Input.GetMouseButtonDown(1)) 
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
			{
				agent.destination = hit.point;
				Look_target = hit.point;
			}
		}
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
		{
			Look_target = hit.point;
		}
		LookHere ();
        if (current_weapon.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                weapon.SetBool("throwing", true);
                StartCoroutine(throw_weap());
            }
            if (Input.GetKeyDown(KeyCode.A))
                weapon.SetBool("hitting", true);
        }
		
	}
	void LookHere()
	{
		if (Look_target != LastLook_target)
		{
			CalculateAngle(Look_target);
			if(view_angle > 3)
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotation_speed * UnityEngine.Time.deltaTime);
		}
	}
	private void CalculateAngle(Vector3 temp)
	{
		dir = new Vector3(temp.x, transform.position.y, temp.z) - transform.position;
		view_angle = Vector3.Angle(dir, transform.forward);
	}

    IEnumerator throw_weap ()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        create_throw = Instantiate(current_weapon, current_weapon.transform.position, current_weapon.transform.rotation) as GameObject;
        create_throw.transform.localScale = transform.localScale;
        current_weapon.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        current_weapon.SetActive(true);
    }
		
}
