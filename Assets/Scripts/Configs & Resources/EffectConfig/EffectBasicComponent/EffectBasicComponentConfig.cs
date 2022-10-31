using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectBasicComponentConfig : ScriptableObject
{
    public float Duration;
    public float Interval;
    public float Amount;

    public abstract EffectBasicComponent GetEffectBasicComponent();
}