using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBasicComponent 
{
    protected float m_CountDown;
    protected float m_IntervalCountDown;
    protected bool m_OnCountDown = false;
    protected bool m_Applied = false;

    private EffectBasicComponentConfig m_EffectBasicComponentConfig;
    public EffectBasicComponent(EffectBasicComponentConfig config)
    {
        m_EffectBasicComponentConfig = config;
    }
    public void ApplyEffectBasicComponent(Tank tank)
    {
        if (!m_Applied)
        {
            // if not count down yet
            if (!m_OnCountDown)
            {
                // Start Count down 
                OnStartApplyEffectBasicComponent(tank);
            }
            else
            {
                // if during count down
                if (m_CountDown >= 0)
                {
                    OnApplyEffectBasicComponent(tank);
                }
                else
                {
                    OnEndApplyEffectBasicComponent(tank);
                }
            }
        }
    }

    protected virtual void OnStartApplyEffectBasicComponent(Tank tank)
    {
        m_OnCountDown = true;
        m_CountDown = m_EffectBasicComponentConfig.Duration;
        m_IntervalCountDown = 0;
    }

    protected virtual void OnApplyEffectBasicComponent(Tank tank)
    {

        // Only apply after every time intervals
        if (m_IntervalCountDown <= 0)
        {
            ApplyEffectBasicComponentAction(tank, m_EffectBasicComponentConfig);
            m_IntervalCountDown = m_EffectBasicComponentConfig.Interval;
        }
        m_CountDown -= Time.deltaTime;
        m_IntervalCountDown -= Time.deltaTime;

    }

    protected virtual void OnEndApplyEffectBasicComponent(Tank tank)
    {
        // stop count down and apply actions
        m_Applied = true;
        m_OnCountDown = false;
        m_CountDown = 0;
        m_IntervalCountDown = 0;
    }

    // apply each component depend on their type
    protected virtual void ApplyEffectBasicComponentAction(Tank tank, EffectBasicComponentConfig config)
    {
        
    }



    #region Getter Setter
    public bool IsApplied()
    {
        return m_Applied;
    }


    #endregion
}
