using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fan Firing Config", menuName = "Fan Firing Style Config")]
public class FanFiringStyleConfig : FiringStyleConfig
{
    public override BaseFiring GetBaseFiring(TankShooting tankShooting)
    {
        return new FanFiring(tankShooting);
    }
}
