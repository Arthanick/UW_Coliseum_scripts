using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisabled;

	// Use this for initialization
	void Start () {
		if (!isLocalPlayer)
        {
            for (int i =0; i<componentsToDisabled.Length; i++)
            {
                componentsToDisabled [i].enabled = false;
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
