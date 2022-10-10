using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringControl: MonoBehaviour
{
    private int m_TotalBulletWave;
    private float m_BulletWaveInterval;
    //private FiringStyleConfig m_FiringStyleConfig;
    private BaseFiring NewFiringStyle(MyEnum.FireStyle fireStyle)
    {
        switch (fireStyle)
        {
            case MyEnum.FireStyle.SINGLE_FIRE:
                m_TotalBulletWave = 1;
                m_BulletWaveInterval = 0f;
                return new SingleFiring();

            case MyEnum.FireStyle.RAPID_FIRE:
                m_TotalBulletWave = 3;
                m_BulletWaveInterval = 0.1f;
                return new RapidFiring();

            case MyEnum.FireStyle.FAN_FIRE:
                m_TotalBulletWave = 1;
                m_BulletWaveInterval = 0;
                return new FanFiring();

            default:
                return null;

        }
    }


    public Transform m_FireTransform;

    public MyEnum.FireStyle m_FiringStyleEnum = MyEnum.FireStyle.SINGLE_FIRE;
    private MyEnum.FireStyle m_LastFiringStyle;

    private BaseFiring m_FiringStyle ;

    private bool m_Firing;
    private float m_LauchForce;


    private int m_BulletWaveCount;
    private float m_IntervalCountDown;

    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public AudioSource m_ShootingAudio;


    private void Start()
    {
        // INIT FIRING STYLE
        m_FiringStyle = NewFiringStyle(m_FiringStyleEnum);
        m_LastFiringStyle = m_FiringStyleEnum;

    }
    private void Update()
    {
        // Save previous firing style, if current firing style enum change, create a new Firing STYLE
        if (m_FiringStyleEnum != m_LastFiringStyle)
        {
            m_FiringStyle = NewFiringStyle(m_FiringStyleEnum);
            m_LastFiringStyle = m_FiringStyleEnum;
        }
       

    }

    private void FixedUpdate()
    {
        if (m_Firing)
        {
            // if finish firing
            if (m_BulletWaveCount >= m_TotalBulletWave)
            {
                m_Firing = false;
                return;
            }
            // fire
            if (m_IntervalCountDown <= 0)
            {
                Fire(m_LauchForce);
                ++m_BulletWaveCount;
                Debug.Log("m_BulletWaveCount: " + m_BulletWaveCount);

                m_IntervalCountDown = m_BulletWaveInterval;

            }
            else
            {
                m_IntervalCountDown -= Time.deltaTime;
            }
            //CheckEndFiring();
        }
    }


    private void InitFiringStyleConfig() { 

    }

    // signal the flag for firing control start to update with firing methods
    public void StartFiring(float launchForce)
    {
        m_BulletWaveCount = 0;
        m_IntervalCountDown = 0;
        m_Firing = true;
        m_LauchForce = launchForce;
    }

    // if the firing method has finish its behaviors (how it fire shells), then fire control also stop
    public void CheckEndFiring()
    {
        if(!m_FiringStyle.IsFiring())
            m_Firing = false;
    }

    private void Fire(float launchForce)
    {
        m_FiringStyle.Fire(m_FireTransform, launchForce);
    }

    public bool IsFiring()
    {
        return this.m_Firing;
    }

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
