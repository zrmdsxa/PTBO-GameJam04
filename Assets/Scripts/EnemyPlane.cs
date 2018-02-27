using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
public class EnemyPlane : MonoBehaviour
{


    public WaypointCircuit m_patrolCircuit;
    public WaypointCircuit m_playerCircuit;
    WaypointProgressTracker m_wpt;


    public Transform m_bullet1;

    public float m_fireRate1;

    public float m_bullet1Speed;

    public float m_bullet1Damage;

    public float m_minRange1;
    public float m_maxRange1;

	public float m_attackRange;

	public GameObject m_gunSound1;

    public Transform[] m_gun1Positions;

    float m_currentCooldown1 = 0;

    bool m_inRange = false;

    Rigidbody m_rb;

    // Use this for initialization
    void Start()
    {
        name = "A6M";
        m_wpt = GetComponent<WaypointProgressTracker>();
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((PlayerScript.m_player.transform.position - transform.position).magnitude);
        if ((PlayerScript.m_player.transform.position - transform.position).magnitude <= m_attackRange)
        {
            m_wpt.circuit = m_playerCircuit;
            m_inRange = true;
        }
        else
        {
            m_wpt.circuit = m_patrolCircuit;
            m_inRange = false;
        }

        if (m_currentCooldown1 < m_fireRate1)
        {
            m_currentCooldown1 += Time.deltaTime;
        }

        if (m_inRange)
        {
            //Debug.Log(Vector3.Angle(transform.forward, PlayerScript.m_player.transform.position - transform.position));
            if (Vector3.Angle(transform.forward, PlayerScript.m_player.transform.position - transform.position) < 15.0f)
            {
                if (m_currentCooldown1 >= m_fireRate1)
                {
                    foreach (Transform t in m_gun1Positions)
                    {
                        Transform bullet = Instantiate(m_bullet1, t.position, Quaternion.identity);
						Destroy(Instantiate(m_gunSound1,transform.position,Quaternion.identity),5);

                        bullet.GetComponent<Bullet>().SetDamage(m_bullet1Damage);

                        Rigidbody rb = bullet.GetComponent<Rigidbody>();
                        //rb.velocity = m_rb.velocity + (transform.forward * m_bullet1Speed) + (transform.up * Random.Range(m_minRange1, m_maxRange1)) + (transform.right * Random.Range(m_minRange1, m_maxRange1));
                        rb.velocity = (((PlayerScript.m_player.transform.position + PlayerScript.m_playerRB.velocity) - t.position).normalized * m_bullet1Speed) + (transform.up * Random.Range(m_minRange1, m_maxRange1)) + (transform.right * Random.Range(m_minRange1, m_maxRange1));

                        bullet.tag = "Enemy bullets";
                        bullet.gameObject.layer = 12;

                        m_currentCooldown1 = 0;
                    }
                }
            }

        }

        if (transform.position.y < 5.0f)
        {
        
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);

        }

    }

}