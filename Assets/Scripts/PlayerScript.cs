using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public static GameObject m_player;
	public static Rigidbody m_playerRB;

	// Use this for initialization
	void Start () {
		m_player = gameObject;
		m_playerRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
