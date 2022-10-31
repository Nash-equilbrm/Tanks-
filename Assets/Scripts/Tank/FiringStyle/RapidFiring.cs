using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFiring : BaseFiring
{
    public RapidFiring(TankShooting tankShooting) : base(tankShooting)
    {

    }

    public override void Fire(Transform fireTransform, float launchForce)
    {
        SingleFire(fireTransform, launchForce);
    }

}
