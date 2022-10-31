using UnityEngine;

public class BaseFiring
{
    protected TankShooting m_TankShooting;
    public BaseFiring(TankShooting tankShooting)
    {
        m_TankShooting = tankShooting;
    }
    public virtual void Fire(Transform fireTransform, float launchForce)
    {
    }
    public void SingleFire(Transform fireTransform, float launchForce)
    {
        GameObject shellInstance = ObjectPooler.Instance.SpawnFromPool("shell" + m_TankShooting.m_PlayerID.ToString(), fireTransform.position, fireTransform.rotation);

        shellInstance.GetComponent<Rigidbody>().velocity = launchForce * fireTransform.forward;

    }
    
}
