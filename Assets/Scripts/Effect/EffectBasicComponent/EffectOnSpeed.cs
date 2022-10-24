using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnSpeed : EffectBasicComponent
{
    public EffectOnSpeed(EffectBasicComponentConfig config): base(config)
    {

    }

    protected override void ApplyEffectBasicComponentAction(Tank tank, EffectBasicComponentConfig config)
    {
        TankMovement tankMovement = tank.GetTankMovement();
        tankMovement.ChangeSpeedByAmount(config.Amount);
    }

    protected override void OnEndApplyEffectBasicComponent(Tank tank)
    {
        base.OnEndApplyEffectBasicComponent(tank);
        tank.GetTankMovement().ResetOriginalSpeed();
    }

}
