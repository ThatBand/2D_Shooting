using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Object/StageData")]
public class SpawnData : ScriptableObject
{
    public SpawnEntry[] spawnList;
}
