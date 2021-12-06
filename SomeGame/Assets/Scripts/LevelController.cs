using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public event EventHandler<int> OnKillsChanged;
    public event EventHandler<int> OnScoreChanged;

    [SerializeField]
    private int levelIndex;


    private int totalKills = 0;
    private DateTime levelTime;
    private int scorePoints = 0;


    public static LevelController Instance { get; private set; }
    public int TotalKills { get => totalKills;

        set 
        {
            totalKills = value;
            scorePoints += 100;
            OnKillsChanged?.Invoke(this, value);
        }
    }

    public DateTime LevelTime { get => levelTime; set => levelTime = value; }
    public int ScorePoints { get => scorePoints; set => scorePoints = value; }
    public int LevelIndex { get => levelIndex; set => levelIndex = value; }
    public int LevelIndex1 { get => levelIndex; set => levelIndex = value; }

    void Start()
    {
        WinScreen winScreen = new WinScreen();
        levelIndex = StartLevelData.LevelIndex;
    }


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

}
