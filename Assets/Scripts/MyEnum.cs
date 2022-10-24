using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnum
{
    public enum FireStyle
    {
        // Fire 1 bullet
        SINGLE_FIRE = 0,
        // Fire multiple bullets seperated by an interval of time in 1 shot attempt
        RAPID_FIRE = 1,
        // Fire multiple bullets at different directions at the same time
        FAN_FIRE = 2
    }

    public enum ShellType
    {
        NORMAL_SHELL = 0,
        // flying bullet does not under the influence of gravity
        FLYING_SHELL = 1,
        // chasing bullet follow enemy until explode
        CHASING_SHELL = 2
    }

    public enum ShellTrajectory
    {
        NORMAL_TRAJECTORY = 0,
        // Continueously tracking enemy position in range until destroyed
        CHASE_TARGET_TRAJECTORY = 1
    }

    public enum Effect
    {
        NONE = 0,
        STUN = 1,
        TOXIC = 2,
        HEAL = 3,
        IMMUNITY = 4
    }

    public enum EffectBasicComponent
    {
        SPEED = 0,
        HEALTH = 1,
        OTHER_EFFECT = 2
    }
}
