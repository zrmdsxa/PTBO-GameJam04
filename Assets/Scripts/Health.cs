using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Health : MonoBehaviour {

	public float m_startHealth = 100;

	public Text m_playerText;

	public Image m_playerImage;

	public Image m_enemyImage;

	float m_currentHealth;

	// Use this for initialization
	void Start () {
		m_currentHealth = m_startHealth;

		if (name == "F4U"){
			m_playerText.text = ((m_currentHealth/m_startHealth)*100).ToString("0") +"%";
			m_playerImage.fillAmount = m_currentHealth/m_startHealth;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage){
		if (damage > 0.0f){
			if (name == "A6M"){
				//enemy plane loses pitch control when hit
				GetComponent<AeroplaneController>().m_PitchEffect -= 0.2f;
			}
			m_currentHealth -= damage;

			Debug.Log(name+":"+m_currentHealth+"/"+m_startHealth);

			if (m_currentHealth <= 0.0f){
				//dead condition
			}

			if (name == "F4U"){
				m_playerText.text = ((m_currentHealth/m_startHealth)*100).ToString("0") +"%";
				m_playerImage.fillAmount = m_currentHealth/m_startHealth;
			}

			if (tag == "Enemy"){
				m_enemyImage.fillAmount = m_currentHealth / m_startHealth;
			}
		}
	}
}
