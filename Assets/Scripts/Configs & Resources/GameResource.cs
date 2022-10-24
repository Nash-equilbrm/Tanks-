using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResource : MonoBehaviour
{
    #region Singleton
    public static GameResource Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public GameObject ShellPrefab;
    public GameObject TankPrefab;
}
