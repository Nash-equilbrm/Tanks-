using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTrajectoryControl : MonoBehaviour
{
    public MyEnum.ShellType m_ShellTypeEnum = MyEnum.ShellType.NORMAL_SHELL;
    public MyEnum.ShellType m_LastShellTypeEnum;

    private BaseShellTrajectory trajectory;

    // Start is called before the first frame update
    void Start()
    {
        m_LastShellTypeEnum = m_ShellTypeEnum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
