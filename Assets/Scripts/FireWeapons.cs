using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	public Transform m_rocketPrefab;

	public Text m_rocketText;

	public float m_rocketCooldown;

	float m_currentRocketCooldown = 0;

	public Transform[] m_rocketPositions;

	int m_rocketIndex = 0;

	Rigidbody m_rb;

	Transform[] m_rockets;

    // Use this for initialization
    void Start()
    {
		m_rb = GetComponent<Rigidbody>();

		m_rockets = new Transform[m_rocketPositions.Length];

		LoadRockets();
		
    }

    // Update is called once per frame
    void Update()
    {
        if (m_currentCooldown1 < m_fireRate1)
        {
            m_currentCooldown1 += Time.deltaTime;
        }

		if (m_currentRocketCooldown > 0 && m_rocketIndex == m_rocketPositions.Length){
			m_currentRocketCooldown -= Time.deltaTime;
			m_rocketText.text = m_currentRocketCooldown.ToString("0");
		}

		if (m_currentRocketCooldown <= 0 && m_rocketIndex == m_rocketPositions.Length){
			m_rocketIndex = 0;
			LoadRockets();
		}

        if (Input.GetButton("Attack"))
        {
            if (m_currentCooldown1 >= m_fireRate1)
            {
                foreach (Transform t in m_gun1Positions)
                {
                    Transform bullet = Instantiate(m_bullet1, t.position, Quaternion.identity);

					bullet.GetComponent<Bullet>().SetDamage(m_bullet1Damage);

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

				//add rigidbody
				m_rockets[m_rocketIndex].gameObject.AddComponent(typeof(Rigidbody));
				Rigidbody rb = m_rockets[m_rocketIndex].GetComponent<Rigidbody>();
				rb.useGravity = false;
				rb.velocity = m_rb.velocity + transform.forward * 50.0f;

				//enable smoke trail
				m_rockets[m_rocketIndex].GetChild(1).gameObject.SetActive(true);

				m_rocketIndex++;

				m_rocketText.text = "x "+(m_rocketPositions.Length-m_rocketIndex);
				
				if (m_rocketIndex == m_rocketPositions.Length){
					m_currentRocketCooldown = m_rocketCooldown;
				}
			}
			
		}

    }

	void LoadRockets(){
		for (int i = 0 ; i < m_rocketPositions.Length; i++){
			m_rockets[i] = Instantiate(m_rocketPrefab,m_rocketPositions[i].position,transform.rotation);
			m_rockets[i].SetParent(transform);
		}

		m_rocketText.text = "x "+(m_rocketPositions.Length-m_rocketIndex);
	}
}
