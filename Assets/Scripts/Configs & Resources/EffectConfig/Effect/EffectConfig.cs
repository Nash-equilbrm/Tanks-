using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect Config", menuName = "Effect")]
public class EffectConfig : ScriptableObject
{
    public bool BeneficialForTarget;
    public EffectBasicComponentConfig[] EffectBasicComponents;
}
