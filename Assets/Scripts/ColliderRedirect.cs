using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRedirect : MonoBehaviour {

	public GameObject m_parent;

	public GameObject GetParent(){
		return m_parent;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.layer == 11 || other.gameObject.layer == 0){
			m_parent.GetComponent<Health>().PlayerDieInstant();
		}
	}
}
