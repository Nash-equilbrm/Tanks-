using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Single Firing Config", menuName = "Single Firing Style Config")]
public class SingleFiringStyleConfig : FiringStyleConfig
{
    public override BaseFiring GetBaseFiring(TankShooting tankShooting)
    {
        return new SingleFiring(tankShooting);
    }
}
