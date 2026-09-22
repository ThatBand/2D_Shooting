using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public EnemyData enemyData;
    public float curHealth;

    public GameObject item;
    public Image healthBar;

    public GameObject shield;

    public bool isInvin;

    private EnemyHit hit;
    private BossPatternManager manager;
    private BossDeathEffect deathEffect;

    private int curPhase = 0;

    private bool isHit;

    private void Awake()
    {
        curHealth = enemyData.health;
        hit = GetComponent<EnemyHit>();
        manager = GetComponent<BossPatternManager>();
        deathEffect = GetComponent<BossDeathEffect>();
    }

    public void TakeDamage(float damage)
    {
        if (isInvin)
            return;

        if (isHit)
            return;

        isHit = true;
        curHealth -= damage;
        isHit = false;

        hit?.OnHit();

        if (healthBar != null)
            healthBar.fillAmount = curHealth / enemyData.health;

        if (hit.isBoss)
        {
            if (curHealth <= (enemyData.health / 3) * 2 && curPhase < 2)
            {
                curPhase = 2;
                manager?.EnterPhase2();
            }

            else if (curHealth <= (enemyData.health / 3) && curPhase < 3)
            {
                curPhase = 3;
                manager?.EnterPhase3();
            }
        }

        if (curHealth <= 0)
        {
            if (shield != null)
                shield.SetActive(false);

            if (hit.isBoss)
            {
                ScoreManager.instance.ScorePlus(enemyData.enemyScore);
                deathEffect?.BossDeath();
                SoundManager.instance.EnemyDeathSound();
            }

            else
                Destroy(gameObject);
        }
    }
}
