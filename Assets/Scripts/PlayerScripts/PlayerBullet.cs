using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public bool isInduce;

    private bool isHit;

    //protected override void OnEnable()
    //{
    //    base.OnEnable();

    //    isHit = false;

    //    if (!isInduce)
    //        rigid.AddForce(transform.up * bulletData.speed, ForceMode2D.Impulse);
    //}

    //protected override void OnDisable()
    //{
    //    base.OnDisable();
    //}

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        isHit = false;
        if (!isInduce)
            rigid.AddForce(transform.up * bulletData.speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (GameManager.instance.boss != null && isInduce)
        {
            Vector2 direction = (Vector2)GameManager.instance.boss.position - (Vector2)transform.position;
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            transform.Rotate(0, 0, -rotateAmount * 200 * Time.deltaTime);
        }

        transform.Translate(Vector3.up * bulletData.speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
            return;

        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out DamageReceiver receiver))
            {
                isHit = true;
                receiver.ReceiveDamage(bulletData.damage);
                //PoolManager.Instance.Return(poolName, gameObject);

                Destroy(gameObject);
            }

            else if (receiver == null)
            {
                isHit = true;

                if (collision.TryGetComponent(out EnemyHealth enemyHealth))
                    enemyHealth.TakeDamage(bulletData.damage);

                //PoolManager.Instance.Return(poolName, gameObject);

                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("EnemyBullet"))
        {
            if (collision.TryGetComponent(out EnemyBullet eBullet) && eBullet.type == EnemyBullet.bulletType.yellow)
            {
                Debug.Log("노랑 총알과 충돌");
                eBullet.TakeDamage(bulletData.damage);
                isHit = true;
                //PoolManager.Instance.Return(poolName, gameObject);

                Destroy(gameObject);
            }

            isHit = true;
        }

        if (collision.CompareTag("Boundary"))
        {
            //PoolManager.Instance.Return(poolName, gameObject);
            Destroy(gameObject);
        }
            
    }
}
