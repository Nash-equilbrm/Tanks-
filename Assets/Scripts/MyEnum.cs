using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnum
{
    public enum FireStyle
    {
        // Fire 1 bullet
        SINGLE_FIRE = 0,
        // Fire multiple bullets at different directions at the same time
        FAN_FIRE = 1,
        // Fire multiple bullets seperated by an interval of time in 1 shot attempt
        RAPID_FIRE = 2
    }

    public enum ShellType
    {
        NORMAL_SHELL,
        // flying bullet does not under the influence of gravity
        FLYING_SHELL,
        // chasing bullet follow enemy until explode
        CHASING_SHELL
    }
}
