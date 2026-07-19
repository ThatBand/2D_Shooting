using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Scriptable Object/BulletData")]
public class BulletData : ScriptableObject
{
    public float speed;
    public float damage;
    public float health;
}
