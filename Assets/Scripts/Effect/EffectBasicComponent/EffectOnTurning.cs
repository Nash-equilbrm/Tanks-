using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOnTurning : EffectBasicComponent
{
    public EffectOnTurning(EffectBasicComponentConfig config) : base(config)
    {

    }
    protected override void ApplyEffectBasicComponentAction(Tank tank, EffectBasicComponentConfig config)
    {
        TankMovement tankMovement = tank.GetTankMovement();
        tankMovement.ChangeTurningSpeedOnAmount(config.Amount);
    }

    protected override void OnEndApplyEffectBasicComponent(Tank tank)
    {
        base.OnEndApplyEffectBasicComponent(tank);
        tank.GetTankMovement().ResetOriginalTurnSpeed();
    }
}