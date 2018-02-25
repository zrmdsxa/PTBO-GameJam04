using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Health : MonoBehaviour
{

    public float m_startHealth = 100;

    public Text m_playerText;

    public Image m_playerImage;

    public Image m_enemyImage;

    public GameObject m_explosionSound;

    public GameObject m_explosionParticles;

    float m_currentHealth;

    bool m_isDead = false;

    // Use this for initialization
    void Start()
    {
        m_currentHealth = m_startHealth;

        if (name == "F4U")
        {
            m_playerText.text = ((m_currentHealth / m_startHealth) * 100).ToString("0") + "%";
            m_playerImage.fillAmount = m_currentHealth / m_startHealth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (m_isDead)
        {
            transform.Translate(new Vector3(0, -1 * Time.deltaTime, 0));
            if (transform.position.y == 0)
            {
                if (name == "F4U")
                {
					PlayerDieInstant();
                }
				else if (name == "A6M"){
					Destroy(gameObject);
					Destroy(Instantiate(m_explosionSound, transform.position, Quaternion.identity), 5);
                    Destroy(Instantiate(m_explosionParticles, transform.position, Quaternion.identity), 5);
				}
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!m_isDead)
        {
            if (damage > 0.0f)
            {
                if (name == "A6M")
                {
                    //enemy plane loses pitch control when hit
                    GetComponent<AeroplaneController>().m_PitchEffect -= 0.2f;
                }
                m_currentHealth -= damage;

                Debug.Log(name + ":" + m_currentHealth + "/" + m_startHealth);

                if (name == "F4U")
                {
                    m_playerText.text = ((m_currentHealth / m_startHealth) * 100).ToString("0") + "%";
                    m_playerImage.fillAmount = m_currentHealth / m_startHealth;
                }

                if (tag == "Enemy" || tag == "EnemyChild")
                {
                    m_enemyImage.fillAmount = m_currentHealth / m_startHealth;
                }

                if (m_currentHealth <= 0.0f)
                {
					Debug.Log(name+" died");
                    m_isDead = true;
                    m_currentHealth = 0.0f;
                    if (name == "F4U")
                    {
                        GetComponent<FireWeapons>().enabled = false;
                        GetComponent<AeroplaneController>().m_MaxEnginePower = 0;
                        GetComponent<AeroplaneController>().ShowPropeller();
                        GetComponent<AeroplaneController>().enabled = false;
                        GetComponent<AeroplaneUserControl4Axis>().enabled = false;

                        m_playerText.text = ("0%");
                        m_playerImage.fillAmount = 0;
                    }

                    else if (name == "A6M")
                    {
                        GetComponent<EnemyPlane>().enabled = false;
                    }

					else if (name == "dumboat" || name == "PirateShip"){
						BoatCounter.m_instance.BoatDestroyed();
						GetComponent<EnemyScript>().enabled = false;
					}

					if (name == "dumboat"){
						Debug.Log("dum boat ded");
						GetComponentInChildren<Animator>().SetBool("dead",true);
					}

                    Destroy(Instantiate(m_explosionSound, transform.position, Quaternion.identity), 5);
                    Destroy(Instantiate(m_explosionParticles, transform.position, Quaternion.identity), 5);

                }


            }
        }
    }
    public void PlayerDieInstant()
    {
        GetComponent<FireWeapons>().enabled = false;
        GetComponent<AeroplaneController>().m_MaxEnginePower = 0;
        GetComponent<AeroplaneController>().ShowPropeller();
        GetComponent<AeroplaneController>().enabled = false;
        GetComponent<AeroplaneUserControl4Axis>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(transform.GetChild(2).gameObject);

        m_playerText.text = ("0%");
        m_playerImage.fillAmount = 0;
        Destroy(Instantiate(m_explosionSound, transform.position, Quaternion.identity), 5);
        Destroy(Instantiate(m_explosionParticles, transform.position, Quaternion.identity), 5);
    }


}
