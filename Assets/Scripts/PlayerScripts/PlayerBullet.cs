using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void Start()
    {
        base.Start();
        rigid.AddForce(transform.up * bulletData.speed, ForceMode2D.Impulse);
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
