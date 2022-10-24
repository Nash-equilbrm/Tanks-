using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    #region Singleton
    public static GameConfig Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Firing style configs
    [SerializeField] private FiringStyleConfig[] m_FiringStyleConfigs;
    public FiringStyleConfig FiringConfig(int configID) {
        return m_FiringStyleConfigs[configID];
    }

    // Shell type configs
    [SerializeField] private ShellTrajectoryConfig[] m_ShellTrajectoryConfigs;
    public ShellTrajectoryConfig ShellTrajectoryConfig(int configID)
    {
        return m_ShellTrajectoryConfigs[configID];
    }

    // Effect config
    [SerializeField] private EffectConfig[] m_EffectConfig;
    public EffectConfig EffectConfig(int configID)
    {
        return m_EffectConfig[configID];
    }
}
