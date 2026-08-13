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

    public bool isInvin;

    private EnemyHit hit;
    private BossPatternManager manager;
    private BossDeathEffect deathEffect;

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

        curHealth -= damage;

        hit?.OnHit();

        if (healthBar != null)
            healthBar.fillAmount = curHealth / enemyData.health;

        if (hit.isBoss && curHealth <= (enemyData.health / 2))
        {
            manager?.EnterPhase2();
        }

        if (curHealth <= 0)
        {
            ScoreManager.instance.ScorePlus(enemyData.enemyScore);
            deathEffect?.BossDeath();
            GameManager.instance.isGameClear = true;

            if (!hit.isBoss)
                Destroy(gameObject);
        }
    }
}
