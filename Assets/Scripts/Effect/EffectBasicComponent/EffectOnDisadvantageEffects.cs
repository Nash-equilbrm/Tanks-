using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnDisadvantageEffects : EffectBasicComponent
{
    public EffectOnDisadvantageEffects(EffectBasicComponentConfig config) : base(config)
    {

    }

    protected override void ApplyEffectBasicComponentAction(Tank tank, EffectBasicComponentConfig config)
    {
        TankEffectManager tankEffectManagement = tank.GetTankEffectManager();
        tankEffectManagement.RemoveDisadvantageEffect();
    }
}
