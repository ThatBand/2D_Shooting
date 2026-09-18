using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStrike : MonoBehaviour
{
    public EnemyData data;
    public Transform[] points;

    [Header("총알 등장 확률")]
    public float red;
    public float blue;
    public float yellow;

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
                SoundManager.instance.BossShotSound_0();

                bullets[k] = Instantiate(data.enemyBullet[0], points[k]);

                if (bullets[k].TryGetComponent(out EnemyBullet eBullet))
                    BulletUtility.SetRandomType(eBullet, red, blue, yellow);

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(1);

            foreach (GameObject bullet in bullets)
            {
                if (bullet != null)
                    bullet.GetComponent<StrikeBullet>()?.Fire();
            }

            yield return new WaitForSeconds(2);
        }

        manager.ChangeState(BossState.Idle);
    }
}
