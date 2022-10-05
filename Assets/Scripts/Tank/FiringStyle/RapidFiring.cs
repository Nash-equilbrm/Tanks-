using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFiring : BaseFiring
{
    private float m_Interval = 0.2f;
    private float m_CountDown = 0;
    private int m_BulletTotal = 3;
    private int m_BulletCount = 0; 


    public override void Fire(Transform fireTransform, float launchForce)
    {
        base.Fire(fireTransform, launchForce);
        if (m_BulletCount == m_BulletTotal)
        {
            m_OnFiring = false;
            m_BulletCount = 0;
            m_CountDown = 0;
        }
        else
        {
            if (m_CountDown <= 0)
            {
                SingleFire(fireTransform, launchForce);
                m_CountDown = m_Interval;
                m_BulletCount++;
            }
            else
            {
                m_CountDown -= Time.deltaTime;
            }
        }
    }

}
