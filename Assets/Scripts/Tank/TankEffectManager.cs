using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEffectManager : MonoBehaviour
{
    [SerializeField] private Tank m_Tank;


    private List<Effect> m_ActiveEffects;

    private void Start()
    {
        m_ActiveEffects = new List<Effect>();
    }

    private void FixedUpdate()
    {
        ApplyEffects(m_Tank);
        RemoveEffects();
    }

    public void AddNewEffect(MyEnum.Effect effectEnum)
    {
        Effect newEffect = NewEffect(effectEnum);
        if (newEffect != null)
        {
            m_ActiveEffects.Add(newEffect);
        }
        SortEffectByPriority();

    }

    private void RemoveEffects()
    {
        List<Effect> effectToRemove = new List<Effect>();
        // get all expired effects
        foreach (Effect effect in m_ActiveEffects)
        {
            if (effect.ToBeRemove())
            {
                effectToRemove.Add(effect);
            }
        }
        // remove expired effects
        foreach (Effect effect in effectToRemove)
        {
            m_ActiveEffects.Remove(effect);
        }

    }


    private void ApplyEffects(Tank tank)
    {
        foreach (Effect effect in m_ActiveEffects)
        {
            effect.ApplyEffect(tank);
        }
    }

    public void RemoveDisadvantageEffect()
    {
        // get all expired effects
        foreach (Effect effect in m_ActiveEffects)
        {
            if (!effect.GetConfig().BeneficialForTarget)
            {
                effect.ForceRemove(m_Tank);
                effect.SetToRemove(true);
            }
        }

    }

    private Effect NewEffect(MyEnum.Effect effectEnum)
    {
        return new Effect(GameConfig.Instance.EffectConfig((int)effectEnum));
    }

    public void ResetActiveEffect()
    {
        foreach (Effect effect in m_ActiveEffects)
        {
            effect.SetEffectActive(true);
        }
    }

    public void SortEffectByPriority()
    {
        for (int i = 0; i < m_ActiveEffects.Count; ++i)
        {
            for (int j = i + 1; j < m_ActiveEffects.Count; ++j)
            {
                if (m_ActiveEffects[i].GetConfig().Priority < m_ActiveEffects[j].GetConfig().Priority)
                {
                    Effect tmp = m_ActiveEffects[i];
                    m_ActiveEffects[i] = m_ActiveEffects[j];
                    m_ActiveEffects[j] = tmp;
                }
            }

        }
    }

}
