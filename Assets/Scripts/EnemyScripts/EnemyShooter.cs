using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyBullet;

public class EnemyShooter : MonoBehaviour
{
    public EnemyData enemyData;

    public int attackCount;

    private float attackSpeed;
    private float time;

    private bool isCharging;

    private GameObject enemyBullet;
    private EnemyMove move;

    private GameObject curBullet;

    private void Awake()
    {
        attackSpeed = enemyData.attackSpeed;
        enemyBullet = enemyData.enemyBullet[0];
        move = GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyData.shootType == ShootType.Normal)
            time += Time.deltaTime;

        Fire();
    }

    private void OnDestroy()
    {
        if (enemyData.shootType != ShootType.Charging)
            return;

        isCharging = false;

        if (curBullet.GetComponent<ChargingBullet>().isCharging && curBullet != null)
            Destroy(curBullet);
    }

    void Fire()
    {
        switch (enemyData.shootType)
        {
            case ShootType.Normal:
                if (attackSpeed > time)
                    return;

                GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                Rigidbody2D bulletRigid = bullet.GetComponent<Rigidbody2D>();
                EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
                bulletScript.Setup(bulletType.red);
                Vector3 dir = GameManager.instance.player.transform.position - transform.position;

                bulletRigid?.AddForce(dir.normalized * bulletScript.bulletData.speed, ForceMode2D.Impulse);
                bulletRigid.angularVelocity = 100;

                time = 0;
                break;
            case ShootType.Charging:
                StartCoroutine(ChargingShoot());
                break;
        }
    }

    IEnumerator ChargingShoot()
    {
        if (isCharging)
            yield break;

        isCharging = true;
        int count = 0;

        while (count < attackCount)
        {
            //1초간 내려옴으로서 플레이어에게 적이 생성됨을 알려줌
            yield return new WaitForSeconds(1f);
            move.isStop = true;

            GameObject curBullet = Instantiate(enemyData.enemyBullet[0], transform.position + Vector3.down * 1.2f, Quaternion.identity);
            EnemyBullet bulletSC = curBullet.GetComponent<EnemyBullet>();
            bulletSC.Setup(bulletType.red);

            //총알 생성 후 발사까지 걸리는 속도
            yield return new WaitForSeconds(2f);

            count++;
        }

        yield return new WaitForSeconds(4f);
        move.isStop = false;
    }
}
