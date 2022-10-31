using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turning Effect Component", menuName = "Turning Effect Component")]
public class EffectOnTurningConfig : EffectBasicComponentConfig
{
    public override EffectBasicComponent GetEffectBasicComponent()
    {
        return new EffectOnTurning(this);
    }
}
