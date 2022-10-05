using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanFiring : BaseFiring
{
    public override void Fire(Transform fireTransform, float launchForce)
    {
        base.Fire(fireTransform, launchForce);
        SingleFire(fireTransform, launchForce);
    }
}

