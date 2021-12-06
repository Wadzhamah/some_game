using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Enemy[] enemies;
    public static EnemyManager Instance { get; private set; }
    public Enemy TargetEnemy { get => targetEnemy; set => targetEnemy = value; }
    public Enemy[] Enemies { get => enemies; set => enemies = value; }

    private Enemy targetEnemy;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Start()
    {
       enemies = FindObjectsOfType<Enemy>();
    }
}

