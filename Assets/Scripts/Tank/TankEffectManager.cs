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
        Debug.Log("AddNewEffect: " + effectEnum.ToString());    
        Effect newEffect = NewEffect(effectEnum);
        if(newEffect != null)
        {
            m_ActiveEffects.Add(newEffect);
        }
       
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
        foreach(Effect effect in m_ActiveEffects)
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
                effect.SetToRemove(true);
            }
        }
       
    }

    private Effect NewEffect(MyEnum.Effect effectEnum)
    {
        switch (effectEnum)
        {
            case MyEnum.Effect.STUN:
            case MyEnum.Effect.HEAL: 
            case MyEnum.Effect.TOXIC:
            case MyEnum.Effect.IMMUNITY:
                {
                    return new Effect(GameConfig.Instance.EffectConfig((int) effectEnum));
                }
           
            default:
                {
                    return null;
                }
        }
    }

    public void ResetActiveEffect()
    {
        foreach (Effect effect in m_ActiveEffects)
        {
            effect.SetEffectActive(true);
        }
    }
}
