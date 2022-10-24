using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speed Effect Component", menuName = "Speed Effect Component")]
public class EffectOnSpeedConfig : EffectBasicComponentConfig
{
    public override EffectBasicComponent GetEffectBasicComponent()
    {
        return new EffectOnSpeed(this);
    }
}
