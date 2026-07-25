using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCircleFire : MonoBehaviour
{
    public EnemyData bossData;

    public Transform[] movePos;

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

    private int currentTargetIndex = 0;
    private Vector3 startPos;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        startPos = transform.position;

        StartCoroutine(MoveToPosition());
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

    IEnumerator MoveToPosition()
    {
        while (true)
        {
            Transform targetPos = movePos[currentTargetIndex];

            while (Vector3.Distance(transform.position, targetPos.position) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos.position, 4.5f * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator CirclePattern()
    {
        currentTargetIndex = 0;
        int a = 0;

        yield return new WaitForSeconds(0.5f);

        while (a < patternCount)
        {
            for (int k = 0; k < 2; k++)
            {
                float randSpeed = Random.Range(70f, 75f);

                for (int i = 0; i < bulletCount; i++)
                {
                    GameObject bullet = Instantiate(bossData.enemyBullet[3], transform.position + Vector3.down * 0.6f, Quaternion.identity);

                    if (bullet.TryGetComponent(out EnemyBullet eBullet))
                        BulletProbability(eBullet);

                    float b = (360f / bulletCount) * i;
                    Vector3 moveDir = Quaternion.Euler(0, 0, b) * Vector3.up;

                    bullet.transform.localRotation = Quaternion.Euler(0, 0, b + 90);

                    if (bullet.TryGetComponent(out Rigidbody2D rigid))
                        rigid.AddForce(moveDir * randSpeed);
                }

                yield return new WaitForSeconds(0.3f);
            }

            yield return new WaitForSeconds(fireDelay);

            a++;
            if (a < movePos.Length)
                currentTargetIndex = a;
        }

        transform.position = startPos;
        manager.ChangeState(BossState.Idle);
    }
}
