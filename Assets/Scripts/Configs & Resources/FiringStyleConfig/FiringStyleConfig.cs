using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiringStyleConfig : ScriptableObject
{
    public int TotalBulletWave;
    public float Interval;

    public abstract BaseFiring GetBaseFiring(TankShooting tankShooting);
}