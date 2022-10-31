using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private MyEnum.Effect m_ItemEffect;
    [SerializeField] private LayerMask m_TankLayerMask;
    private Vector3 m_OriginalPos;
    private float m_FloatingRange = 0.3f;
    private bool m_FloatUp = true;
    private bool m_IsUsed = false;
    private void Awake()
    {
        m_OriginalPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (!m_IsUsed)
        {
            Floating(m_FloatingRange);
        }
        else
        {
            //transform.position += Vector3.up * Time.deltaTime * 100f;
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // if collide with tanks, apply effect
        if(Utils.IsInLayerMask(other.gameObject, m_TankLayerMask))
        {
            ApplyEffectOnTank(other.gameObject);
            m_IsUsed = true;
        }
    }

    private void ApplyEffectOnTank(GameObject tankObj)
    {
        Tank tank = tankObj.GetComponent<Tank>();
        TankEffectManager tankEffectManager = tank.GetTankEffectManager();
        tankEffectManager.AddNewEffect(m_ItemEffect);
    }



    private void Floating(float range)
    {
        if (m_FloatUp)
        {
            if (transform.position.y > m_OriginalPos.y + range)
            {
                m_FloatUp = false;
            }
            else
            {
                transform.position += Vector3.up * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.y < m_OriginalPos.y - range)
            {
                m_FloatUp = true;
            }
            else
            {
                transform.position -= Vector3.up * Time.deltaTime;
            }
        }
    }

}
