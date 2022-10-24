using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    private EffectConfig m_EffectConfig;
    private EffectBasicComponent[] m_EffectBasicComponents;
    private bool m_IsActive = true;
    private bool m_ToBeRemove = false;

    public Effect(EffectConfig config)
    {
        m_EffectConfig = config;
        m_EffectBasicComponents = new EffectBasicComponent[m_EffectConfig.EffectBasicComponents.Length];
        for(int i =0; i < m_EffectConfig.EffectBasicComponents.Length; ++i)
        {
            m_EffectBasicComponents[i] = NewEffectBasicComponent(m_EffectConfig.EffectBasicComponents[i]);
        }
    }

    private EffectBasicComponent NewEffectBasicComponent(EffectBasicComponentConfig config)
    {
        return config.GetEffectBasicComponent();
    }

    public void ApplyEffect(Tank tank)
    {
        if (m_IsActive)
        {
            foreach (EffectBasicComponent effectBasicComponent in m_EffectBasicComponents)
            {
                effectBasicComponent.ApplyEffectBasicComponent(tank);
            }
            if (CheckToBeRemove())
            {
                m_ToBeRemove = true;
            }
        }
        
    }

    // Check if every effect components are applied
    private bool CheckToBeRemove()
    {
        int cnt = 0;
        foreach (EffectBasicComponent effectBasicComponent in m_EffectBasicComponents)
        {
            if (effectBasicComponent.IsApplied())
                ++cnt;
        }
        return cnt == m_EffectBasicComponents.Length;
    }

    #region Getter Setter
    public EffectConfig GetConfig()
    {
        return m_EffectConfig;
    }

    public void SetEffectActive(bool active)
    {
        m_IsActive = active;
    }

    public bool ToBeRemove()
    {
        return m_ToBeRemove;
    }

    public void SetToRemove(bool toRemove)
    {
        m_ToBeRemove = toRemove;
    }

    #endregion

}
