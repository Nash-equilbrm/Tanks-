using System;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public LayerMask m_BulletMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;

    [SerializeField] private ShellEffectConfig m_ShellEffectConfig;

    //private void Start()
    //{
    //    Destroy(gameObject, m_MaxLifeTime);
    //}

    private void OnTriggerExit(Collider other)
    {
        if(IsInLayerMask(other.gameObject, m_BulletMask))
        {
            return;
        }
        // Find all the tanks in an area around the shell and damage them.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        
        for(int i = 0; i < colliders.Length; ++i)
        {
            // Calculate and deal damage to players
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            
            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            Tank targetTank = targetRigidbody.GetComponent<Tank>();
            //TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            TankHealth targetHealth = targetTank.GetTankHealth();

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);


            // Apply effect on tanks except for original one
            ApplyEffectOnOpponents(targetTank);


        }
        //m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();

        m_ExplosionAudio.Play();

        //Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    private void ApplyEffectOnOpponents(Tank tank)
    {
        if(m_ShellEffectConfig != null)
        {
            tank.GetTankEffectManager().AddNewEffect(m_ShellEffectConfig.EffectEnum);
        }
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        float damage = relativeDistance * m_MaxDamage;

        damage = Mathf.Max(0f, damage);
        return 0;
    }

    public bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }



}