using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEntry
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    [HideInInspector]
    public float timer;
}
