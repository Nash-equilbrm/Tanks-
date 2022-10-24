using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnShooting : EffectBasicComponent
{
    public EffectOnShooting(EffectBasicComponentConfig config) : base(config)
    {

    }

    protected override void ApplyEffectBasicComponentAction(Tank tank, EffectBasicComponentConfig config)
    {
        tank.GetTankShooting().SetActive(false);
    }

    protected override void OnEndApplyEffectBasicComponent(Tank tank)
    {
        base.OnEndApplyEffectBasicComponent(tank);

        tank.GetTankShooting().SetActive(true);
    }

    
}
