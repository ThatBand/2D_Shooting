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
    private PlayerInvincibility invincibility;

    private void Awake()
    {
        invincibility = GetComponent<PlayerInvincibility>();
    }

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

        invincibility.StartInvincibility();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(boomData.amount);
    
        GameManager.instance.ClearBullet();

        //GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        //for (int i = 0; i < enemyBullets.Length; i++)
        //{
        //    Vector3 spawnPos = enemyBullets[i].transform.position;

        //    Instantiate(coin, spawnPos, Quaternion.identity);
        //    Destroy(enemyBullets[i]);
        //}

        curBoom--;
        uiManager.UseBoomIcon(curBoom);
        effectManager.OnBoomEffect();
    }
}
