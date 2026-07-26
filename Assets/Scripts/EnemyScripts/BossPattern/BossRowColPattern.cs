using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRowColPattern : MonoBehaviour
{
    [Header("보스 데이터")]
    public EnemyData bossData;

    [Header("총알 등장 확률")]
    public float red;
    public float blue;
    public float yellow;

    [Header("총알이 생성될 X시작, 끝 위치")]
    public float startX;
    public float endX;

    [Header("총알이 생성될 Y시작, 끝 위치")]
    public float startY;
    public float endY;

    [Header("발사할 총알 갯수")]
    public int bulletCount;

    public int patternCount;
    public float patternDelay;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(TopToBottom());
        StartCoroutine(BottomToTop());
        StartCoroutine(LeftToRight());
        StartCoroutine(RightToLeft());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
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

    IEnumerator TopToBottom()
    {
        float spacingX = (endX - startX) / (bulletCount - 1);

        for (int i = 0; i < patternCount; i++)
        {
            for (int k = 0; k < bulletCount; k++)
            {
                float spawnX = startX + (spacingX * k);
                Vector2 spawnPos = new Vector2(spawnX, startY);

                GameObject bullet = Instantiate(bossData.enemyBullet[4], spawnPos, Quaternion.identity);
                BulletProbability(bullet.GetComponent<EnemyBullet>());

                bullet.GetComponent<Rigidbody2D>()?.AddForce(Vector2.down * 70);
            }

            yield return new WaitForSeconds(patternDelay);
        }

        yield return new WaitForSeconds(10);

        manager.ChangeState(BossState.Idle);
    }

    IEnumerator BottomToTop()
    {
        float spacingX = (endX - startX) / (bulletCount - 1);

        for (int i = 0; i < patternCount; i++)
        {
            for (int k = 0; k < bulletCount; k++)
            {
                float spawnX = startX + (spacingX * k);
                Vector2 spawnPos = new Vector2(spawnX, endY);

                GameObject bullet = Instantiate(bossData.enemyBullet[4], spawnPos, Quaternion.identity);
                BulletProbability(bullet.GetComponent<EnemyBullet>());

                bullet.GetComponent<Rigidbody2D>()?.AddForce(Vector2.up * 70);
            }

            yield return new WaitForSeconds(patternDelay);
        }
    }

    IEnumerator LeftToRight()
    {
        float spacingY = (endY - startY) / (bulletCount - 1);

        for (int i = 0; i < patternCount; i++)
        {
            for (int k = 0; k < bulletCount; k++)
            {
                float spawnY = startY + (spacingY * k);
                Vector2 spawnPos = new Vector2(startX, spawnY);

                GameObject bullet = Instantiate(bossData.enemyBullet[4], spawnPos, Quaternion.identity);
                BulletProbability(bullet.GetComponent<EnemyBullet>());

                bullet.GetComponent<Rigidbody2D>()?.AddForce(Vector2.right * 70);
            }

            yield return new WaitForSeconds(patternDelay);
        }
    }

    IEnumerator RightToLeft()
    {
        float spacingY = (endY - startY) / (bulletCount - 1);

        for (int i = 0; i < patternCount; i++)
        {
            for (int k = 0; k < bulletCount; k++)
            {
                float spawnY = startY + (spacingY * k);
                Vector2 spawnPos = new Vector2(endX, spawnY);

                GameObject bullet = Instantiate(bossData.enemyBullet[4], spawnPos, Quaternion.identity);
                BulletProbability(bullet.GetComponent<EnemyBullet>());

                bullet.GetComponent<Rigidbody2D>()?.AddForce(Vector2.left * 70);
            }

            yield return new WaitForSeconds(patternDelay);
        }
    }
}
