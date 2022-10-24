using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HP Effect Component", menuName = "HP Effect Component")]
public class EffectOnHPConfig : EffectBasicComponentConfig
{
    public override EffectBasicComponent GetEffectBasicComponent()
    {
        return new EffectOnHP(this);
    }
}
