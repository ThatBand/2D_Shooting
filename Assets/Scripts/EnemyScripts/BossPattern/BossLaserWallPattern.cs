using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserWallPattern : MonoBehaviour
{
    public EnemyData data;

    public GameObject enemy_L;

    public Vector2[] targetPos;
    public int bulletCount;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(MakeEnemy());
    }

    IEnumerator MakeEnemy()
    {
        for (int i = 0; i < targetPos.Length; i++)
        {
            yield return null;

            GameObject enemy = Instantiate(enemy_L, targetPos[i], Quaternion.identity);
        }

        yield return new WaitForSeconds(3);

        StartCoroutine(CircularPattern());
        yield break;
    }

    IEnumerator CircularPattern()
    {
        while (true)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject bullet = Instantiate(data.enemyBullet[5], transform.position, Quaternion.identity);

                float b = (360 / bulletCount) * i;
                Vector3 moveDir = Quaternion.Euler(0, 0, b) * Vector3.up;

                if (bullet.TryGetComponent(out Rigidbody2D rigid))
                    rigid.AddForce(moveDir * 50);
            }

            yield return new WaitForSeconds(5);
        }
    }
}