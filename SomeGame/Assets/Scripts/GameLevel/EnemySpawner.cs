using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyTemplate;
    [SerializeField]
    private List<EnemySpawnPoint> enemySpawnPoints;

    private void Start()
    {
        for (int i = 0; i < StartLevelData.LevelIndex; i++)
        { 
        
            Instantiate(enemyTemplate, enemySpawnPoints[i].transform, false);
        }
    }
}
