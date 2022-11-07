using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }    //ENCAPSULATION
    [SerializeField] private GameObject[] enemyPlanes;
    private float rangeX = 100;
    private float spawnY = 160;
    private float startSpawnTime = 1.5f;
    private float spawnRate = 2.5f;
    private float m_score = 0;
    private int playerLives = 3;
    public float score
    {
        // ENCAPSULATION
        get { return m_score; }
        set
        {
            if (value < m_score)
            {
                Debug.LogError("You cannot subsctract from score or lower score.");
            }
            else
            {
                m_score = value;
            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyPlanes", startSpawnTime, spawnRate);
    }

    public void LoseLife()
    {
        playerLives--;
    }


    void SpawnEnemyPlanes()
    {
        int index = Random.Range(0, enemyPlanes.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-rangeX,rangeX), 15, spawnY);

        Instantiate(enemyPlanes[index], spawnPos, enemyPlanes[index].transform.rotation);
    }
}
