using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

[System.Serializable]
public class GameDataManager : MonoBehaviour
{
    public LevelDataManager levelDataManager;
    public static GameDataManager Instance { get; private set; }
    private void Awake()
    {
        levelDataManager = new LevelDataManager();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public static void Save<T>(T data, string key)
    {
        string json = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(key, json);
    }

    public static void Load<T>(string key, Action<T> onHasResult, Action onResultNull = null)
    {
        T result;
        if (PlayerPrefs.HasKey(key) == true)
        {
            string jsonData = PlayerPrefs.GetString(key);
            result = JsonConvert.DeserializeObject<T>(jsonData);
            onHasResult.Invoke(result);
        }
        else
        {
            result = default;
            onResultNull?.Invoke();
        }
    }
}
