using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graze : MonoBehaviour
{
    [Header("그레이즈 성공 시 획득할 경험치")]
    public int grazeScore;

    [Header("그레이즈 성공 횟수")]
    public int grazeCount;

    [Header("모아야할 폭탄 조각 수")]
    public int bombPiece;
    private int savePiece;

    private PlayerHealth playerHealth;
    private PlayerInvincibility playerInvincibility;
    private PlayerInventory inventory;

    private void Start()
    {
        savePiece = bombPiece;
    }

    private void Awake()
    {
        inventory = GetComponentInParent<PlayerInventory>();
        playerInvincibility = GetComponentInParent<PlayerInvincibility>();
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") && !playerInvincibility.IsInvincibility && !playerHealth.isDead)
        {
            if (collision.TryGetComponent(out EnemyBullet eBullet) && eBullet.type != EnemyBullet.bulletType.blue)
            {
                Debug.Log("총알과 충돌!, 그레이즈 점수 획득!");
                SoundManager.instance.GrazeSound();
                grazeCount++;
                ScoreManager.instance.ScorePlus(grazeScore);

                if (grazeCount == bombPiece)
                {
                    Debug.Log("폭탄 조각 모두 획득");
                    inventory.AddBoom();
                    Debug.Log("폭탄 추가!");
                    bombPiece += savePiece;
                }
            }
        }
    }
}
