using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

	public string m_name;
    public float m_attackRange = 1000.0f;

    public Transform m_bullet1;

    public float m_fireRate1;

    public float m_bullet1Speed;

    public float m_bullet1Damage;

    public float m_minRange1;
    public float m_maxRange1;

	public GameObject m_gunSound1;

    public Transform[] m_gun1Positions;

    float m_currentCooldown1 = 0;

    bool m_inRange = false;

    Animator m_anim;

    // Use this for initialization
    void Start()
    {
		name = m_name;
        m_anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((PlayerScript.m_player.transform.position - transform.position).magnitude <= m_attackRange)
        {
            m_inRange = true;
            //Debug.Log("IN RANGE");
            if (m_anim != null)
            {
                m_anim.SetBool("inRange", true);
            }
        }
        else
        {
            m_inRange = false;
            //Debug.Log("NOT IN RANGE");
            if (m_anim != null)
            {
                m_anim.SetBool("inRange", false);
            }
        }

        if (name == "dumboat")
        {
			//only turn around Y axis
            transform.LookAt(PlayerScript.m_player.transform, Vector3.up);
            Quaternion r = transform.rotation;
            r.x = 0;
            r.z = 0;
            transform.rotation = r;
        }

		if (m_currentCooldown1 < m_fireRate1)
        {
            m_currentCooldown1 += Time.deltaTime;
        }

        if (m_inRange)
        {

            if (m_currentCooldown1 >= m_fireRate1)
            {
                foreach (Transform t in m_gun1Positions)
                {
                    Transform bullet = Instantiate(m_bullet1, t.position, Quaternion.identity);

					Destroy(Instantiate(m_gunSound1,transform.position,Quaternion.identity),5);

                    bullet.GetComponent<Bullet>().SetDamage(m_bullet1Damage);

                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                
                    rb.velocity = (((PlayerScript.m_player.transform.position + PlayerScript.m_playerRB.velocity*0.75f) - t.position).normalized * m_bullet1Speed) + (transform.up * Random.Range(m_minRange1, m_maxRange1)) + (transform.right * Random.Range(m_minRange1, m_maxRange1));

                    bullet.tag = "Enemy bullets";
                    bullet.gameObject.layer = 12;

                    m_currentCooldown1 = 0;
                }
            }


        }
    }
}
