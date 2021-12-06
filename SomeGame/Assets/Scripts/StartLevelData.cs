using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelData : MonoBehaviour
{
    public static StartLevelData Instance {get; private set;}
    
    public static int LevelIndex { get; set;}
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
