using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shooting Effect Component", menuName = "Shooting Effect Component")]
public class EffectOnShootingConfig : EffectBasicComponentConfig
{
    public override EffectBasicComponent GetEffectBasicComponent()
    {
        return new EffectOnShooting(this);
    }
}
