using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnData stageData;
    public Transform[] spawnPoints;

    public int randEnemy;
    public int randPoint;

    public float timer;

    private void Start()
    {
        timer = stageData.spawnList[randEnemy].timer;

        randEnemy = Random.Range(0, stageData.spawnList.Length);
        randPoint = Random.Range(0, spawnPoints.Length);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (stageData.spawnList[randEnemy].spawnInterval <= timer)
        {
            GameObject enemy = Instantiate(stageData.spawnList[randEnemy].enemyPrefab, spawnPoints[randPoint].position, Quaternion.identity);
            timer = 0;

            randEnemy = Random.Range(0, stageData.spawnList.Length);
            randPoint = Random.Range(0, spawnPoints.Length);
        }
    }
}