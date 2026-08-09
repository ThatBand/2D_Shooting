using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserWallPattern : MonoBehaviour
{
    public EnemyData data;

    public GameObject enemy_L;

    public Vector2[] targetPos;

    [Header("총알 등장 확률")]
    public float red;
    public float blue;
    public float yellow;

    [Header("총알 개수")]
    public int bulletCount;

    [Header("패턴 발동 횟수")]
    public int circlePatternCount;

    [Header("패턴을 넘어갈 시간")]
    public float passPatternTime;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(MakeEnemy());
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
        int a = 0;

        while (a < circlePatternCount)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                Debug.Log(bulletCount);
                GameObject bullet = Instantiate(data.enemyBullet[5], transform.position, Quaternion.identity);
                EnemyBullet eb = bullet.GetComponent<EnemyBullet>();
                BulletProbability(eb);

                float b = (360f / bulletCount) * i;
                Vector3 moveDir = Quaternion.Euler(0, 0, b) * Vector3.up;

                if (bullet.TryGetComponent(out Rigidbody2D rigid))
                    rigid.AddForce(moveDir * 50);
            }

            a++;
            bulletCount -= 3;
            yield return new WaitForSeconds(5);
        }

        yield return new WaitForSeconds(passPatternTime);

        GameManager.instance.ClearBullet();
        GameObject[] walls = GameObject.FindGameObjectsWithTag("LaserWall");
        foreach (GameObject wall in walls)
            Destroy(wall);
        manager.ChangeState(BossState.Idle);
    }
}