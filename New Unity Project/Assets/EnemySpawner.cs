using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float TimeOfSpawn;
    public float SpawnTime = 5f;
    public GameObject enemy;
    public Transform player;
    private void Start()
    {
        TimeOfSpawn = 0;
    }
    void Update()
    {
        if (TimeOfSpawn + Time.time >= SpawnTime + Time.time)
        {
            TimeOfSpawn = 0;
            SpawnEnemy();
        }
        TimeOfSpawn += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        float xSpawn = Random.Range(player.position.x - 200, player.position.x + 200);
        float ySpawn = Random.Range(0, player.position.y + 10);
        float zSpawn = Random.Range(player.position.y - 200, player.position.y + 200);
        Debug.Log($"Spawned enemy at: {xSpawn}, {ySpawn}, {zSpawn}.");
        GameObject enemyl = GameObject.Instantiate<GameObject>(enemy);
        enemyl.transform.position = new Vector3(xSpawn, Random.Range(0, 50), zSpawn);
    }
}
