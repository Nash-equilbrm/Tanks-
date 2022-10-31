using System;
using UnityEngine;

[Serializable]
public class TankManager
{
    public Color m_PlayerColor;            
    public Transform m_SpawnPoint;         
    [HideInInspector] public int m_PlayerID;             
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance;          
    [HideInInspector] public int m_Wins;                     


    private TankMovement m_Movement;       
    private TankShooting m_Shooting;
    private TankHealth m_Health;
    private TankLaserShooting m_LaserShooting;
    private GameObject m_CanvasGameObject;


    public void Setup()
    {
        Tank tank = m_Instance.GetComponent<Tank>();
        m_Movement = tank.GetTankMovement();
        m_Shooting = tank.GetTankShooting();
        m_Health = tank.GetTankHealth();
        m_LaserShooting = tank.GetLaserShooting();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_Health.m_PlayerID = m_PlayerID;
        m_Movement.m_PlayerID = m_PlayerID;
        m_Shooting.m_PlayerID = m_PlayerID;
        m_LaserShooting.m_PlayerID = m_PlayerID;

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerID + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }

        // Create new pool of shells for this tank
        string shellPoolTag = PublicVariables.ShellPoolTag + m_PlayerID.ToString();
        ObjectPooler.Instance.pools.Add(new ObjectPooler.Pool(shellPoolTag, GameResource.Instance.ShellPrefab, PublicVariables.ShellPoolSize));

        
    }

    public void SetTankIDToShells()
    {
        string shellPoolTag = PublicVariables.ShellPoolTag + m_PlayerID.ToString();

        for (int i = 0; i < PublicVariables.ShellPoolSize; ++i)
        {
            GameObject shell = ObjectPooler.Instance.poolDictionnary[shellPoolTag].Dequeue() as GameObject;
            shell.GetComponent<Shell>().SetTankID(m_PlayerID);
            ObjectPooler.Instance.poolDictionnary[shellPoolTag].Enqueue(shell);
        }
    }

    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
