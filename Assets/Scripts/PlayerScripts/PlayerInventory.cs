using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int curBoom;

    public GameObject coin;

    public EffectManager effectManager;
    public UIManager uiManager;
    private ItemData boomData;

    public void AddBoom(ItemData data)
    {
        if (boomData == null)
            boomData = data;

        if (curBoom >= data.maxCount)
        {
            ScoreManager.instance.ScorePlus(500);
            return;
        }

        curBoom++;
        uiManager.GetBoomIcon(curBoom);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            UseBoom();
    }

    void UseBoom()
    {
        if (curBoom == 0)
            return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            EnemyHealth enemyHealth = enemies[i].GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(boomData.amount);
        }

        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i = 0; i < enemyBullets.Length; i++)
        {
            Vector3 spawnPos = enemyBullets[i].transform.position;

            Instantiate(coin, spawnPos, Quaternion.identity);
            Destroy(enemyBullets[i]);
        }

        curBoom--;
        uiManager.UseBoomIcon(curBoom);

        effectManager.OnBoomEffect();
    }
}
