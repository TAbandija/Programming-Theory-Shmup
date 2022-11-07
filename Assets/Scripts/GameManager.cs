using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPlanes;
    private float rangeX = 100;
    private float spawnY = 160;
    private float startSpawnTime = 1.5f;
    private float spawnRate = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyPlanes", startSpawnTime, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyPlanes()
    {
        int index = Random.Range(0, enemyPlanes.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-rangeX,rangeX), 15, spawnY);

        Instantiate(enemyPlanes[index], spawnPos, enemyPlanes[index].transform.rotation);
    }
}
