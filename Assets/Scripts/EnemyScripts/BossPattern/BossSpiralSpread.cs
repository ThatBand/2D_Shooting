using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiralSpread : MonoBehaviour
{
    public Transform bulletContainer;
    public float RotateSpeed;

    [Header("총알 등장 확률")]
    public float red;
    public float blue;
    public float yellow;

    [Header("총알 개수")]
    public int bulletCount;

    [Header("총알 속도")]
    public int bulletSpeed;

    [Header("발사 쿨타임")]
    public float fireTime;
    public EnemyData bossData;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(SprialBullet());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        bulletContainer.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
    }

    private void BulletProbability(EnemyBullet eBullet)
    {
        float total = red + blue + yellow;
        float randNum = Random.Range(0f, total);

        if (randNum < red)
            eBullet.Setup(EnemyBullet.bulletType.red);

        else if (randNum < red + blue)
            eBullet.Setup(EnemyBullet.bulletType.blue);

        else
            eBullet.Setup(EnemyBullet.bulletType.yellow);
    }

    IEnumerator SprialBullet()
    {
        int o = 0;

        while ( o < 30)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject bullet = Instantiate(bossData.enemyBullet[1], bulletContainer.position, Quaternion.identity, bulletContainer);
                EnemyBullet bullstSC = bullet.GetComponent<EnemyBullet>();
                BulletProbability(bullstSC);

                Rigidbody2D bulletRigid = bullet.GetComponent<Rigidbody2D>();

                float a = (360f / bulletCount) * i + 1;
                bullet.transform.localRotation = Quaternion.Euler(0, 0, a);
                bulletRigid.AddForce(bullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
            }

            o++;
            yield return new WaitForSeconds(fireTime);
        }

        manager.ChangeState(BossState.Idle);
    }
}
