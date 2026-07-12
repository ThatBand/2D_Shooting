using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStrike : MonoBehaviour
{
    public EnemyData data;
    public Transform[] points;

    private GameObject[] bullets;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        bullets = new GameObject[points.Length];

        StartCoroutine(MakeBullet());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator MakeBullet()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < bullets.Length; k++)
            {
                bullets[k] = Instantiate(data.enemyBullet[0], points[k]);
                EnemyBullet bulletSC = bullets[k].GetComponent<EnemyBullet>();
                bulletSC.Setup(EnemyBullet.bulletType.red);

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(1);

            foreach (GameObject bullet in bullets)
            {
                bullet.GetComponent<StrikeBullet>()?.Fire();
            }

            yield return new WaitForSeconds(2);
        }

        manager.ChangeState(BossState.Idle);
    }
}
