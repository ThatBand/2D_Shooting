using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public bool isInduce;

    protected override void Start()
    {
        base.Start();

        if (!isInduce)
            rigid.AddForce(transform.up * bulletData.speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (target != null && isInduce)
        {
            Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
            direction.Normalize();

            // 현재 전방(transform.up)과 보스 방향 사이의 각도 차이 계산
            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            // 보스 쪽으로 조금씩 꺾기
            transform.Rotate(0, 0, -rotateAmount * 200 * Time.deltaTime);
        }

        transform.Translate(Vector3.up * bulletData.speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out DamageReceiver receiver))
            {
                receiver.ReceiveDamage(bulletData.damage);
                Destroy(gameObject);
            }

            else if (receiver == null)
            {
                if (collision.TryGetComponent(out EnemyHealth enemyHealth))
                    enemyHealth.TakeDamage(bulletData.damage);
            }
        }

        if (collision.CompareTag("EnemyBullet"))
        {
            if (collision.TryGetComponent(out EnemyBullet eBullet) && eBullet.type == EnemyBullet.bulletType.yellow)
            {
                Debug.Log("노랑 총알과 충돌");
                Destroy(gameObject);
                eBullet.EnemyBulletDamaged(bulletData.damage);
            }
        }
    }
}
