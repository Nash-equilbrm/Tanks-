using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shoot Style", menuName = "ShootStyle")]
public class FiringStyleConfig : ScriptableObject
{
    public int TotalBulletWave;
    public float Interval;
}
