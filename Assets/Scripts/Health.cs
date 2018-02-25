using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float m_startHealth = 100;

	public Text m_text;

	public Image m_image;

	float m_currentHealth;

	// Use this for initialization
	void Start () {
		m_currentHealth = m_startHealth;

		m_text.text = ((m_currentHealth/m_startHealth)*100).ToString("0") +"%";
		m_image.fillAmount = m_currentHealth/m_startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage){
		if (damage > 0.0f){
			m_currentHealth -= damage;

			if (m_currentHealth <= 0.0f){
				//dead condition
			}

			if (name == "F4U"){
				m_text.text = ((m_currentHealth/m_startHealth)*100).ToString("0") +"%";
				m_image.fillAmount = m_currentHealth/m_startHealth;
			}
		}
	}
}
