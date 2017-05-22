using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_scripts : MonoBehaviour
{

    private Animator weapon;
    public GameObject cr_weapon;
    private GameObject obj;
	// Use this for initialization
	void Start ()
    {
        weapon = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cr_weapon.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A))
                weapon.SetBool("hitting", true);
            if (Input.GetKeyDown(KeyCode.S))
            {
                weapon.SetBool("throwing", true);
                StartCoroutine(throwning());
            }
        }
    }

    IEnumerator throwning()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        obj = Instantiate(cr_weapon, cr_weapon.transform.position, cr_weapon.transform.rotation) as GameObject;
        obj.transform.localScale = transform.localScale;
        obj.name = "throwed_spire";
        cr_weapon.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        cr_weapon.SetActive(true);
    }

}
