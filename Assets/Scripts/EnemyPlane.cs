using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		name = "A6M";
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log((PlayerScript.m_player.transform.position - transform.position).magnitude);
		if ((PlayerScript.m_player.transform.position - transform.position).magnitude <= 1000){

		}
	}
}
