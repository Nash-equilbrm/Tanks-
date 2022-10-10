using UnityEngine;
using UnityEngine.UI;

public class BaseFiring
{
    protected bool m_OnFiring;
   
    public virtual void Fire(Transform fireTransform, float launchForce)
    {
        //m_OnFiring = true;
    }
    public void SingleFire(Transform fireTransform, float launchForce)
    {
        GameObject shellInstance = ObjectPooler.Instance.SpawnFromPool("shell", fireTransform.position, fireTransform.rotation);
        shellInstance.GetComponent<Rigidbody>().velocity = launchForce * fireTransform.forward;

    }

    public bool IsFiring()
    {
        return m_OnFiring;
    }

}
