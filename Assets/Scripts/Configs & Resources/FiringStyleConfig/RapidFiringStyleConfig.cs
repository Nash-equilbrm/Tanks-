using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rapid Firing Config", menuName = "Rapid Firing Style Config")]
public class RapidFiringStyleConfig : FiringStyleConfig
{
    public override BaseFiring GetBaseFiring(TankShooting tankShooting)
    {
        return new RapidFiring(tankShooting);
    }
}
