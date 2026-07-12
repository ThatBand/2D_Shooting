using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCircleFire : MonoBehaviour
{
    public EnemyData bossData;

    public Transform bulletContainer;

    public int patternCount;
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

    IEnumerator CirclePattern()
    {
        int a = 0;

        while (a < patternCount)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                bulletContainer.localRotation = Quaternion.Euler(0, 0, (10 * a));

                GameObject[] bullet = new GameObject[bulletCount];
                bullet[i] = Instantiate(bossData.enemyBullet[1], bulletContainer.position, Quaternion.identity, bulletContainer);
                EnemyBullet bulletSC = bullet[i].GetComponent<EnemyBullet>();
                bulletSC.Setup(EnemyBullet.bulletType.red);
                Debug.Log("총알 생성");
                Rigidbody2D bulletRigid = bullet[i].GetComponent<Rigidbody2D>();

                float b = (360f / bulletCount) * i;
                bullet[i].transform.localRotation = Quaternion.Euler(0, 0, b);
                bulletRigid.AddForce(bullet[i].transform.up * 60);
                Debug.Log("총알 발사");
            }

            yield return new WaitForSeconds(fireDelay);

            a++;
        }

        manager.ChangeState(BossState.Idle);
    }
}
