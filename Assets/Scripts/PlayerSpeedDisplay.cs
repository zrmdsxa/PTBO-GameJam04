using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeedDisplay : MonoBehaviour {

	public Text m_text;

	Rigidbody m_rb;
	// Use this for initialization
	void Start () {
		m_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		m_text.text = "Speed: "+(m_rb.velocity.magnitude*3.6f).ToString("0") + " km/h";
	}
}
