using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float m_damage;
	public GameObject m_particle;

	public GameObject m_soundEffect;

	//public float m_lifeTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("Hit:" +other.gameObject.name);
		//if ally bullet
		if (gameObject.layer == 10){ //ally bullets
			if (other.tag == "Enemy"){
				Debug.Log("Tag enemy:" +other.gameObject.name);
				other.GetComponent<Health>().TakeDamage(m_damage);
			}
			else if(other.tag == "EnemyChild"){
				other.GetComponent<ColliderRedirect>().GetParent().GetComponent<Health>().TakeDamage(m_damage);
			}
			DestroyBullet();
		}

		else if (gameObject.layer == 12){
			if (other.tag == "Ally"){
				Debug.Log("Tag ally:" +other.gameObject.name);
				other.GetComponent<Health>().TakeDamage(m_damage);
			}
			else if(other.tag == "AllyChild"){
				other.GetComponent<ColliderRedirect>().GetParent().GetComponent<Health>().TakeDamage(m_damage);
			}
			DestroyBullet();
		}
		else {
			Debug.Log("hit:else tag:"+other.tag+" layer:"+other.gameObject.layer);
			DestroyBullet();
		}
	}

	public void SetDamage(float damage){
		m_damage = damage;
	}

	void DestroyBullet(){
		Destroy(Instantiate(m_particle,transform.position,Quaternion.identity),5);
		if (m_soundEffect != null){
			Destroy(Instantiate(m_soundEffect,transform.position,Quaternion.identity),5);
		}
		
		Destroy(gameObject);
	}
}
