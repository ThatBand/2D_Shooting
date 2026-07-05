using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyData enemyData;
    public float curHealth;

    public GameObject item;

    private EnemyHit hit;

    private void Awake()
    {
        curHealth = enemyData.health;
        hit = GetComponent<EnemyHit>();
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;

        hit?.OnHit();

        if (curHealth <= 0)
        {
            ScoreManager.instance.ScorePlus(enemyData.enemyScore);
            Instantiate(item, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
