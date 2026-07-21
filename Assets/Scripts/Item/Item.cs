using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemHit"))
        {
            UseItem(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void UseItem(GameObject player)
    {
        switch (itemData.type)
        {
            case ItemType.Score:
                ScoreManager.instance.ScorePlus(itemData.amount);
                break;
            case ItemType.Power:
                player.GetComponentInParent<PlayerShooter>()?.UpgradePower(2);
                break;
            case ItemType.Boom:
                player.GetComponentInParent<PlayerInventory>()?.AddBoom();
                break;
        }
    }
}
