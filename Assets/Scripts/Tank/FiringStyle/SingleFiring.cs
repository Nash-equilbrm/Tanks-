using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFiring : BaseFiring
{
    public SingleFiring(int playerID) : base(playerID)
    {

    }
    public override void Fire(Transform fireTransform, float launchForce)
    {
        SingleFire(fireTransform, launchForce);
    }
}
