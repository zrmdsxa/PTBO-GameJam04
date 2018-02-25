using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float m_damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		//if ally bullet
		if (gameObject.layer == 10){
			Debug.Log("Hit:" +other.gameObject.name);
			if (other.tag == "Enemy"){
				Debug.Log("Tag enemy:" +other.gameObject.name);
				other.GetComponent<Health>().TakeDamage(m_damage);
			}
			Destroy(gameObject);
		}
	}

	public void SetDamage(float damage){
		m_damage = damage;
	}
}
