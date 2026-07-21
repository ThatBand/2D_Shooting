using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int curBoomCount;

    public GameObject coin;

    public EffectManager effectManager;
    public UIManager uiManager;

    public ItemData bombData;

    private PlayerInvincibility invincibility;

    private void Awake()
    {
        invincibility = GetComponent<PlayerInvincibility>();
    }

    public void AddBoom()
    {
        if (curBoomCount >= bombData.maxCount)
        {
            ScoreManager.instance.ScorePlus(500);
            return;
        }

        curBoomCount++;
        uiManager.GetBoomIcon(curBoomCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            UseBoom();
    }

    void UseBoom()
    {
        if (curBoomCount == 0)
            return;

        invincibility.StartInvincibility();

        CameraShake.instance.Shake(0.5f, 0.15f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(bombData.amount);
    
        GameManager.instance.ClearBullet();

        //GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        //for (int i = 0; i < enemyBullets.Length; i++)
        //{
        //    Vector3 spawnPos = enemyBullets[i].transform.position;

        //    Instantiate(coin, spawnPos, Quaternion.identity);
        //    Destroy(enemyBullets[i]);
        //}

        curBoomCount--;
        uiManager.UseBoomIcon(curBoomCount);
        effectManager.OnBoomEffect();
    }
}
