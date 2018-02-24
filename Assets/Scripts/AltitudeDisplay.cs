using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AltitudeDisplay : MonoBehaviour {

	public Text m_text;
	Rigidbody m_rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		m_text.text = "Altitude: "+ transform.position.y.ToString("0")+ " m";
	}
}
