using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Heal, Boom, Power, Score };

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public int amount;
    public int maxCount;
    public GameObject itemPrefab;
}
