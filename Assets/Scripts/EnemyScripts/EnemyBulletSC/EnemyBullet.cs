using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    //빨간색: 피하기만 해야함
    //파란색: 부딪히면 점수 획득
    //노란색: 부수면 플레이어 파워 증가
    public enum bulletType { red, blue, yellow };
    public bulletType type;

    public float bulletHealth;

    private SpriteRenderer sprite;

    new private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
    }

    public void Setup(bulletType newType)
    {
        type = newType;

        switch (type)
        {
            case bulletType.red:
                sprite.color = Color.red;
                gameObject.layer = LayerMask.NameToLayer("EnemyInvincibleBullet");
                break;
            case bulletType.blue:
                sprite.color = Color.blue;
                gameObject.layer = LayerMask.NameToLayer("EnemyInvincibleBullet");
                break;
            case bulletType.yellow:
                sprite.color = Color.yellow;
                gameObject.layer = LayerMask.NameToLayer("EnemyBreakableBullet");
                break;
        }
    }

    public void EnemyBulletDamaged(float dmg)
    {
        if (type != bulletType.yellow)
            return;

        bulletHealth -= dmg;

        if (bulletHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.playerShooter.power++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CoreHit"))
        {
            PlayerHealth playerHealth = collision.GetComponentInParent<PlayerHealth>();

            if (type == bulletType.blue)
            {
                Debug.Log("파란색 탄막 흡수! 점수 +500");
                ScoreManager.instance.ScorePlus(500);
            }

            playerHealth?.TakeDamage();
            Destroy(gameObject);
        }
    }
}
