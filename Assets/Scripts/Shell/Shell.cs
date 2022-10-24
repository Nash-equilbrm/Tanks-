using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public LayerMask m_TankLayerMask;
    [SerializeField] private int m_PlayerID;

    [SerializeField] private ShellTrajectoryControl m_ShellTrajectoryControl;
    [SerializeField] private ShellTrajectoryConfig m_ShellTrajectoryConfig;
    private void Start()
    {
        m_ShellTrajectoryControl.InitShellTrajectory(m_ShellTrajectoryConfig.ShellTrajectory);
    }

    public void SetTankID(int ID)
    {
        m_PlayerID = ID;
    }

    public int GetTankID()
    {
        return m_PlayerID;
    }

    private void Update()
    {
        m_ShellTrajectoryControl.ShellMovingUpdate(this);
    }
}
