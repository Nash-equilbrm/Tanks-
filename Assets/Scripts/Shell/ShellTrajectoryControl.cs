using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTrajectoryControl : MonoBehaviour
{
    public static BaseShellTrajectory NewShellTrajectory(MyEnum.ShellType shellTypeEnum)
    {
        switch (shellTypeEnum)
        {
            case MyEnum.ShellType.NORMAL_SHELL:
                return null;
            case MyEnum.ShellType.FLYING_SHELL:
                return null;
            case MyEnum.ShellType.CHASING_SHELL:
                return null;
            default:
                return null;
        }
    }


    public MyEnum.ShellType m_ShellTypeEnum = MyEnum.ShellType.NORMAL_SHELL;
    public MyEnum.ShellType m_LastShellTypeEnum;

    private BaseShellTrajectory m_Trajectory;

    // Start is called before the first frame update
    void Start()
    {
        m_LastShellTypeEnum = m_ShellTypeEnum;
        m_Trajectory = ShellTrajectoryControl.NewShellTrajectory(m_ShellTypeEnum);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ShellTypeEnum != m_LastShellTypeEnum)
        {
            m_LastShellTypeEnum = m_ShellTypeEnum;
            m_Trajectory = ShellTrajectoryControl.NewShellTrajectory(m_ShellTypeEnum);
        }
    }
}
