using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFiring : BaseFiring
{
    public SingleFiring(TankShooting tankShooting) : base(tankShooting)
    {

    }
    public override void Fire(Transform fireTransform, float launchForce)
    {
        SingleFire(fireTransform, launchForce);
    }
}
