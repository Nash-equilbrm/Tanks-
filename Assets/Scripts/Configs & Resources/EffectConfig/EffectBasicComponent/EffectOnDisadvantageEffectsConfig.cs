using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Immunity Effect Component", menuName = "Immunity Effect Component")]
public class EffectOnDisadvantageEffectsConfig : EffectBasicComponentConfig
{
    public override EffectBasicComponent GetEffectBasicComponent()
    {
        return new EffectOnDisadvantageEffects(this);
    }
}
