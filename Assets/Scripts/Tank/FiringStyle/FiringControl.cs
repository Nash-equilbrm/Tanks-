using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TankShooting
{
    //public int m_PlayerID;
    public Transform m_FireTransform;

    [SerializeField] private FiringStyleConfig m_FiringStyleConfig;

    [SerializeField] private MyEnum.FireStyle m_FiringStyleEnum = MyEnum.FireStyle.SINGLE_FIRE;
    private MyEnum.FireStyle m_LastFiringStyle;

    private BaseFiring m_FiringStyle ;

    private bool m_Firing;
    private float m_LauchForce;
    private int m_BulletWaveCount = 0;
    private float m_CountDown = 0;

    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public AudioSource m_ShootingAudio;

    // Initialize current firing style
    public BaseFiring SetUpFiringStyle(MyEnum.FireStyle fireStyle)
    {
        // Get config from Game Config instance
        m_FiringStyleConfig = GameConfig.Instance.FiringConfig((int)fireStyle);

        return m_FiringStyleConfig.GetBaseFiring(m_PlayerID);
    }

    private void FiringControlStart()
    {
        m_FiringStyle = SetUpFiringStyle(m_FiringStyleEnum);

        m_LastFiringStyle = m_FiringStyleEnum;
    }
    private void FiringControlUpdate()
    {
        // Save previous firing style, if current firing style enum change, create a new Firing STYLE
        if (m_FiringStyleEnum != m_LastFiringStyle)
        {
            m_FiringStyle = SetUpFiringStyle(m_FiringStyleEnum);
            m_LastFiringStyle = m_FiringStyleEnum;
        }

        // Keep updating if firing action not finished
        if (m_Firing)
        {
            // if finish firing, stop updating by set the m_Firing flag to false
            if (m_BulletWaveCount == m_FiringStyleConfig.TotalBulletWave)
            {
                OnEndFiring();
            }
            else
            {
                OnFiring();
            }
        }
    }

   

    // signal the flag for firing control start to update with firing methods
    public void OnStartFiring(int playerID, float launchForce)
    {
        m_PlayerID = playerID;

        m_Firing = true;
        m_LauchForce = launchForce;
    }

    // Stop firing
    public void OnEndFiring()
    {
        m_Firing = false;
        m_BulletWaveCount = 0;
        m_CountDown = 0;
    }

    // During firing
    public void OnFiring()
    {
        // fire 1 wave of bullet every interval of time
        if (m_CountDown <= 0)
        {
            Fire(m_LauchForce);
            m_CountDown = m_FiringStyleConfig.Interval;
            m_BulletWaveCount++;
        }
        else
        {
            m_CountDown -= Time.deltaTime;
        }
    }
    public bool IsFiring()
    {
        return this.m_Firing;
    }

    // Firing single bullet wave
    // ** Each Fire method behave differently depend on each firing style
    private void Fire(float launchForce)
    {
        m_FiringStyle.Fire(m_FireTransform, launchForce);
    }

    // Play audio clips
    public void PlayChargingClip()
    {
        m_ShootingAudio.clip = m_ChargingClip;
        m_ShootingAudio.Play();
    }

    public void PlayFireClip()
    {
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
    }

}
