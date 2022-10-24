using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TankHealth m_TankHealth;
    [SerializeField] private TankMovement m_TankMovement;
    [SerializeField] private TankShooting m_TankShooting;
    [SerializeField] private TankEffectManager m_TankEffectManager;


    #region Getter Setter
    public TankMovement GetTankMovement()
    {
        return m_TankMovement;
    }
    public TankShooting GetTankShooting()
    {
        return m_TankShooting;
    }
    public TankHealth GetTankHealth()
    {
        return m_TankHealth;
    }

    public TankEffectManager GetTankEffectManager()
    {
        return m_TankEffectManager;
    }
    #endregion

}
