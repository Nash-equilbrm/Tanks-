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
        SingleFire(fireTransform, launchForce);
    }

}
