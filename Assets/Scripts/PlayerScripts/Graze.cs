using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graze : MonoBehaviour
{
    private PlayerInvincibility playerInvincibility;
    public int grazeScore;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerInvincibility = GetComponentInParent<PlayerInvincibility>();
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") && !playerInvincibility.IsInvincibility && !playerHealth.isDead && collision.GetComponent<EnemyBullet>()?.type != EnemyBullet.bulletType.blue)
        {
            Debug.Log("총알과 충돌!, 그레이즈 점수 획득!");
            ScoreManager.instance.ScorePlus(grazeScore);
        }
    }
}
