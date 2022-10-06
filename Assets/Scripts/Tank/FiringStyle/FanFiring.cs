using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanFiring : BaseFiring
{
    private int m_BulletTotal = 5;
    private float m_MaxAngleBetweenBullets = 20;

    public override void Fire(Transform fireTransform, float launchForce)
    {
        base.Fire(fireTransform, launchForce);

        Quaternion fireTransformOriginalRotation = fireTransform.rotation;
        // rotate to the first bullet's rotation (the outside left bullet)
        float firstBulletRotation = ((float)(m_BulletTotal - 1) / 2) * m_MaxAngleBetweenBullets;
        Debug.Log("firstBulletRotation: " + firstBulletRotation);


        fireTransform.Rotate(new Vector3(0, -firstBulletRotation, 0));

        Vector3 rotateAngle = new Vector3(0, m_MaxAngleBetweenBullets, 0);

        for(int i = 0; i < m_BulletTotal; ++i)
        {
            SingleFire(fireTransform, launchForce);
            fireTransform.Rotate(rotateAngle);
        }

        // rotate back to original rotation
        fireTransform.rotation = fireTransformOriginalRotation;
        m_OnFiring = false;
    }
}

