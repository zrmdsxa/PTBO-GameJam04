using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapons : MonoBehaviour
{

    public Transform m_bullet1;

    public float m_fireRate1;

    public float m_bullet1Speed;

    public float m_bullet1Damage;

	public float m_minRange1;
	public float m_maxRange1;

    public Transform[] m_gun1Positions;

    float m_currentCooldown1 = 0;

	public Transform[] m_rockets;

	int m_rocketIndex = 0;

	Rigidbody m_rb;

    // Use this for initialization
    void Start()
    {
		m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_currentCooldown1 < m_fireRate1)
        {
            m_currentCooldown1 += Time.deltaTime;
        }

        if (Input.GetButton("Attack"))
        {
            if (m_currentCooldown1 >= m_fireRate1)
            {
                foreach (Transform t in m_gun1Positions)
                {
                    Transform bullet = Instantiate(m_bullet1, t.position, Quaternion.identity);

                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.velocity = m_rb.velocity + (transform.forward * m_bullet1Speed) + (transform.up * Random.Range(m_minRange1, m_maxRange1)) + (transform.right * Random.Range(m_minRange1,m_maxRange1));
                
					//bullets go in layer first
					bullet.tag = "Ally bullets";
					bullet.gameObject.layer = 10;

					m_currentCooldown1 = 0;
				}
            }
        }
		if (Input.GetButtonDown("FireRocket"))
        {
			if (m_rocketIndex < 8){
				m_rockets[m_rocketIndex].parent = null;
				m_rockets[m_rocketIndex].gameObject.AddComponent(typeof(Rigidbody));
				Rigidbody rb = m_rockets[m_rocketIndex].GetComponent<Rigidbody>();
				rb.useGravity = false;
				rb.velocity = m_rb.velocity + transform.forward * 50.0f;
				m_rocketIndex++;
			}
			
		}

    }
}
