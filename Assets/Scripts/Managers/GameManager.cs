using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using System;

public class GameManager : MonoBehaviour
{
    public int m_NumRoundsToWin = PublicVariables.NumRoundToWin;        
    public float m_StartDelay = PublicVariables.StartDelay;         
    public float m_EndDelay = PublicVariables.EndDelay;           
    public CameraControl m_CameraControl;   
    public Text m_MessageText;              
    public GameObject m_TankPrefab;         
    public TankManager[] m_Tanks;           


    private int m_RoundNumber;              
     
    private TankManager m_RoundWinner;
    private TankManager m_GameWinner;       




    private void Start()
    {

        SpawnAllTanks();
        SetCameraTargets();
        ObjectPooler.Instance.SetUpPool();
        SetTankIDToShells();
        GameLoop();
    }

    private void SpawnAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].m_Instance = Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerID = i + 1;
            m_Tanks[i].Setup();
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[m_Tanks.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        m_CameraControl.m_Targets = targets;
    }

    private void SetTankIDToShells()
    {
        for(int i = 0; i < m_Tanks.Length; ++i)
        {
            m_Tanks[i].SetTankIDToShells();
        }
    }

    private async void GameLoop()
    {
        //Debug.Log("GameLoop");
        await RoundStarting();
        await RoundPlaying();
        await RoundEnding();


        if (m_GameWinner != null)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            GameLoop();
        }
    }


    private async Task RoundStarting()
    {

        ResetAllTanks();
        DisableTankControl();

        m_CameraControl.SetStartPositionAndSize();

        m_RoundNumber++;

        m_MessageText.text = "ROUND " + m_RoundNumber;

        await Task.Delay((int)(m_StartDelay * 1000));
    }


    private async Task RoundPlaying()
    {

        EnableTankControl();

        m_MessageText.text = string.Empty;

        while (!OneTankLeft())
        {
            await Task.Yield();
        }
    }


    private async Task RoundEnding()
    {

        DisableTankControl();

        m_RoundWinner = null;

        m_RoundWinner = GetRoundWinner();
        if (m_RoundWinner != null)
        {
            m_RoundWinner.m_Wins++;
        }

        m_GameWinner = GetGameWinner();

        string message = EndMessage();
        m_MessageText.text = message;

        await Task.Delay((int)(m_EndDelay * 1000));
    }


    private bool OneTankLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf && m_Tanks[i].m_Instance)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }


    private TankManager GetRoundWinner()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf)
                return m_Tanks[i];
        }

        return null;
    }


    private TankManager GetGameWinner()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
                return m_Tanks[i];
        }

        return null;
    }


    private string EndMessage()
    {
        string message = "DRAW!";

        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
        }

        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        return message;
    }


    private void ResetAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].Reset();
        }
    }


    private void EnableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }


    private void DisableTankControl()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }
}