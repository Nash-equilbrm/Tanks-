using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect Basic Component", menuName = "Effect Basic Component")]
public class EffectBasicComponentConfig : ScriptableObject
{
    public MyEnum.EffectBasicComponent EffectBasicComponentEnum;
    public float Duration;
    public float Interval;
    public float Amount;
}
