using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnHP : EffectBasicComponent
{
    public EffectOnHP(EffectBasicComponentConfig config) : base(config)
    {

    }

    protected override void ApplyEffectBasicComponentAction(Tank tank, EffectBasicComponentConfig config)
    {
        TankHealth tankHealth = tank.GetTankHealth();
        tankHealth.ChangeHPByAmount(config.Amount);
    }
}
