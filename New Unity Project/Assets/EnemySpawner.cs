using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float TimeOfSpawn;
    public float SpawnTime = 5f;
    public GameObject enemy;
    private void Start()
    {
        TimeOfSpawn = 0;
    }
    void Update()
    {
        if (TimeOfSpawn + Time.time >= SpawnTime + Time.time)
        {
            TimeOfSpawn = 0;

        }
        TimeOfSpawn += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        GameObject enemyl = GameObject.Instantiate<GameObject>(enemy);
    }
}
