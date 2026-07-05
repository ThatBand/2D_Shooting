using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void Start()
    {
        base.Start();
        rigid.AddForce(Vector2.up * bulletData.speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DamageReceiver receiver = collision.GetComponent<DamageReceiver>();

            if (receiver != null)
            {
                receiver.ReceiveDamage(bulletData.damage);
                Destroy(gameObject);
            }

            else if (receiver == null)
            {
                EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(bulletData.damage);
            }
        }
    }
}
