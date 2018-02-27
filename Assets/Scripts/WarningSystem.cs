using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSystem : MonoBehaviour {

	public GameObject m_collisionWarning;
	public GameObject m_diveWarning;
	
	public GameObject m_lowWarning;

	Rigidbody m_rb;

	// Use this for initialization
	void Start () {
		m_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= 75){
			m_lowWarning.SetActive(true);
		}
		else{
			m_lowWarning.SetActive(false);
		}

		if(Vector3.Angle(Vector3.down,transform.forward) <=70 && transform.position.y <= 500 && m_rb.velocity.magnitude >= 69){
			m_diveWarning.SetActive(true);
		}
		else{
			m_diveWarning.SetActive(false);
		}
		
	}

	void FixedUpdate(){
		if (Physics.Raycast(transform.position,transform.forward,400,LayerMask.GetMask("Enemy","Default"))){
			m_collisionWarning.SetActive(true);
		}
		else{
			m_collisionWarning.SetActive(false);
		}
	}
}
