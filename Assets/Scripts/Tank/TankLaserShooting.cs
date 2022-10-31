using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankLaserShooting : MonoBehaviour
{
    public int m_PlayerID = 1;


    [SerializeField] private Transform m_LaserFireTransform;
    
    [SerializeField] private float m_LaserDuration = 2f;
    [SerializeField] private float m_LaserRange = 50f;
    [SerializeField] private float m_OriginalDamage = 1f;
    [SerializeField] private float m_DealDamageInterval = 0.5f;
    [SerializeField] private LayerMask m_TankLayerMask;
    [SerializeField] private ParticleSystem m_ExplosionParticle;
    private float m_CurrentDamage;
    private float m_LaserDurationCount;
    private float m_LaserIntervalCount;


    private LineRenderer m_LaserLine;
    private bool m_Fired = false;
    private void Awake()
    {
        m_LaserLine = GetComponentInChildren<LineRenderer>();
    }


    private void Start()
    {
        m_CurrentDamage = m_OriginalDamage;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(m_PlayerID -1) && !m_Fired)
        {
            m_Fired = true;
        }

        if(m_Fired)
        {
            if(m_LaserDurationCount < m_LaserDuration)
            {
                m_LaserLine.enabled = true;
                m_LaserLine.SetPosition(0, m_LaserFireTransform.position);
                RaycastHit hit;
                if (Physics.Raycast(m_LaserFireTransform.position, m_LaserFireTransform.forward, out hit, m_LaserRange))
                {
                    m_LaserLine.SetPosition(1, hit.point);
                    if (Utils.IsInLayerMask(hit.transform.gameObject, m_TankLayerMask))
                    {
                        // Deal damage
                        if (m_LaserIntervalCount >= m_DealDamageInterval)
                        {
                            m_LaserIntervalCount = 0;
                            DealDamage(hit.transform.gameObject);

                            // Set explosion UI
                            m_ExplosionParticle.transform.position = hit.transform.position;
                            m_ExplosionParticle.Play();
                            
                        }
                    }
                    else
                    {
                        ResetDamage();
                    }
                }
                else
                {
                    m_LaserLine.SetPosition(1, m_LaserFireTransform.position + (m_LaserFireTransform.forward * m_LaserRange));
                    ResetDamage();
                }

                m_LaserDurationCount += Time.deltaTime;
                m_LaserIntervalCount += Time.deltaTime;

            }
            else
            {
                m_LaserLine.enabled = false;
                m_Fired = false;
                m_LaserDurationCount = 0;
                ResetDamage();

            }
        }

    }

    private void DealDamage(GameObject gameObject)
    {
        TankHealth tankHealth = gameObject.GetComponent<TankHealth>();
        if (tankHealth)
        {
            tankHealth.TakeDamage(m_CurrentDamage);
            ++m_CurrentDamage;
        }
    }

    private void ResetDamage()
    {
        m_CurrentDamage = m_OriginalDamage;
    }
}
