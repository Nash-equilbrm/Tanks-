using UnityEngine;

public class BaseFiring
{
    private int m_PlayerID;
    public BaseFiring(int playerID)
    {
        m_PlayerID = playerID;
    }
    public virtual void Fire(Transform fireTransform, float launchForce)
    {
    }
    public void SingleFire(Transform fireTransform, float launchForce)
    {
        GameObject shellInstance = ObjectPooler.Instance.SpawnFromPool("shell" + m_PlayerID.ToString(), fireTransform.position, fireTransform.rotation);

        shellInstance.GetComponent<Rigidbody>().velocity = launchForce * fireTransform.forward;

    }
    
}
