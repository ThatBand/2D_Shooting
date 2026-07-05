using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootType { Normal, Charging };

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object/EnemyData")]
public class EnemyData : ScriptableObject
{
    public ShootType shootType;
    public string enemyName;
    public int enemyScore;
    public float speed;
    public float health;
    public float attackSpeed;
    public GameObject[] enemyBullet;
}
