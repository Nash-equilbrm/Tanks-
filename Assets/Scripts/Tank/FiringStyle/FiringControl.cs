using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringControl: MonoBehaviour
{
    public class FiringStyleFactory
    {
        public static BaseFiring NewFiringStyle(MyEnum.FireStyle fireStyle)
        {
            switch (fireStyle)
            {
                case MyEnum.FireStyle.SINGLE_FIRE:
                    return new SingleFiring();

                case MyEnum.FireStyle.RAPID_FIRE:
                    return new RapidFiring();

                case MyEnum.FireStyle.FAN_FIRE:
                    return new FanFiring();

                default:
                    return null;

            }
        }
    }
    public Transform m_FireTransform;

    public MyEnum.FireStyle m_FiringStyleEnum = MyEnum.FireStyle.SINGLE_FIRE;
    private MyEnum.FireStyle m_LastFiringStyle;

    private BaseFiring m_FiringStyle ;

    private bool m_Firing;
    private float m_LauchForce;


    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public AudioSource m_ShootingAudio;

    private void Start()
    {
        m_FiringStyle = FiringStyleFactory.NewFiringStyle(m_FiringStyleEnum);
        m_LastFiringStyle = m_FiringStyleEnum;
    }
    private void Update()
    {
        // Save previous firing style, if current firing style enum change, create a new Firing STYLE
        if (m_FiringStyleEnum != m_LastFiringStyle)
        {
            m_FiringStyle = FiringStyleFactory.NewFiringStyle(m_FiringStyleEnum);
            m_LastFiringStyle = m_FiringStyleEnum;
        }

        if (m_Firing)
        {
            Fire(m_LauchForce);
            OnEndFiring();
        }
    }

    // signal the flag for firing control start to update with firing methods
    public void OnStartFiring(float launchForce)
    {
        m_Firing = true;
        m_LauchForce = launchForce;
    }

    // if the firing method has finish its behaviors (how it fire shells), then fire control also stop
    public void OnEndFiring()
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
