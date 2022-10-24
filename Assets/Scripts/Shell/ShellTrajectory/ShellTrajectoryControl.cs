using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTrajectoryControl : MonoBehaviour
{
    private IShellMoving m_ShellMoving;
    private IShellMoving NewShellTrajectoryMoving(MyEnum.ShellTrajectory shellTrajectoryEnum)
    {
        switch (shellTrajectoryEnum)
        {
            case MyEnum.ShellTrajectory.NORMAL_TRAJECTORY:
                return new ShellNormalMoving();
            case MyEnum.ShellTrajectory.CHASE_TARGET_TRAJECTORY:
                return new ShellChaseTargetMoving();
            default:
                return null;
        }
    }

    public void InitShellTrajectory(MyEnum.ShellTrajectory shellTrajectoryEnum)
    {
        m_ShellMoving = NewShellTrajectoryMoving(shellTrajectoryEnum);
    }

    public void ShellMovingUpdate(Shell shell)
    {
        m_ShellMoving.MoveShell(shell);
    }

}
