using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLookAtPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(PlayerScript.m_player.transform.position - transform.position, Vector3.up);
	}
}
