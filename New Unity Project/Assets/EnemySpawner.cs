using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float TimeOfSpawn;
    public float SpawnTime;

    private void Start()
    {
        TimeOfSpawn = Time.time;
        SpawnTime = Time.time;
    }
    void Update()
    {
        
    }
}
