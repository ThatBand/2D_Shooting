using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCircleFire : MonoBehaviour
{
    public EnemyData bossData;

    public Vector3[] movePos;

    [Header("총알 등장 확률")]
    public float red;
    public float blue;
    public float yellow;

    [Header("패턴 발동 횟수")]
    public int patternCount;

    [Header("총알 개수")]
    public int bulletCount;

    public float fireDelay;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(CirclePattern());
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

    IEnumerator CirclePattern()
    {
        int a = 0;

        while (a < patternCount)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                transform.position = Vector3.Lerp(transform.position, movePos[a], 1);

                GameObject[] bullet = new GameObject[bulletCount];
                bullet[i] = Instantiate(bossData.enemyBullet[3], transform.position + Vector3.down * 0.6f, Quaternion.identity);
                EnemyBullet bulletSC = bullet[i].GetComponent<EnemyBullet>();
                BulletProbability(bulletSC);

                Debug.Log("총알 생성");
                Rigidbody2D bulletRigid = bullet[i].GetComponent<Rigidbody2D>();

                float b = (360f / bulletCount) * i;

                Vector3 moveDir = Quaternion.Euler(0, 0, b) * Vector3.up;
                bullet[i].transform.localRotation = Quaternion.Euler(0, 0, b + 90);
                bulletRigid.AddForce(moveDir * 60);
                Debug.Log("총알 발사");
            }

            yield return new WaitForSeconds(fireDelay);

            a++;
        }

        transform.position = movePos[1];
        manager.ChangeState(BossState.Idle);
    }
}
