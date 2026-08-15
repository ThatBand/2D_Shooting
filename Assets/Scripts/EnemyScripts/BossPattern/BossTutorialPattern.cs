using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTutorialPattern : MonoBehaviour
{
    public Vector3[] targetPos;

    [Header("튜토리얼 키 가이드")]
    public GameObject keyGuideObj;

    [Header("색깔 별 총알 개수")]
    public int blueCount;
    public int yellowCount;

    [Header("반지름 설정")]
    public float blueRadius;
    public float yellowRadius;

    public EnemyData bossData;

    public Transform player;
    public Transform bulletContainer;

    private List<EnemyBullet> blueBullets = new List<EnemyBullet>();

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(RedBulletTutorial());
    }

    IEnumerator RedBulletTutorial()
    {
        for (int i = 0; i < targetPos.Length; i++)
        {
            GameObject bullet = Instantiate(bossData.enemyBullet[6], targetPos[i], Quaternion.identity);
            
            if (bullet.TryGetComponent(out EnemyBullet bulletSC))
                bulletSC.Setup(EnemyBullet.bulletType.red);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(12);
        StartCoroutine(BlueBulletTutorial());
    }

    IEnumerator BlueBulletTutorial()
    {
        if (player.TryGetComponent(out PlayerMove move))
        {
            move.StopPlayer();
            move.enabled = false;
        }

        for (int i = 0; i < blueCount; i++)
        {
            float angle = (360f / blueCount) * i;

            float x = Mathf.Sin(Mathf.Deg2Rad * angle);
            float y = Mathf.Cos(Mathf.Deg2Rad * angle);

            Vector3 a = new Vector3((player.position.x + x * blueRadius), (player.position.y + y * blueRadius), 0);

            GameObject bullet = Instantiate(bossData.enemyBullet[4], a, Quaternion.identity);
            
            if (bullet.TryGetComponent(out EnemyBullet bulletSC))
            {
                bulletSC.Setup(EnemyBullet.bulletType.blue);
                blueBullets.Add(bulletSC);
            }

            yield return new WaitForSeconds(0.05f);
        }

        foreach (EnemyBullet bullet in blueBullets)
        {
            bullet.MoveStart();
        }

        move.enabled = true;

        yield return new WaitForSeconds(5);
        StartCoroutine(YellowBulletTutorial());
    }

    IEnumerator YellowBulletTutorial()
    {
        for (int i = 0; i < yellowCount; i++)
        {
            float angle = (360f / yellowCount) * i;

            float x = Mathf.Sin((Mathf.Deg2Rad * angle));
            float y = Mathf.Cos((Mathf.Deg2Rad * angle));

            Vector3 a = new Vector3(transform.position.x + (x * yellowRadius), transform.position.y + (y * yellowRadius), 0);

            GameObject yellowBullet = Instantiate(bossData.enemyBullet[4], a, Quaternion.identity, bulletContainer);

            if (yellowBullet.TryGetComponent(out EnemyBullet bulletSC))
                bulletSC.Setup(EnemyBullet.bulletType.yellow);

            yield return null;
        }

        float t = 0;

        while (t < 11)
        {
            bulletContainer.Rotate(0, 0, 10 * Time.deltaTime);

            t += Time.deltaTime;
            yield return null;
        }

        keyGuideObj.SetActive(false);
        manager.ChangeState(BossState.Idle);
    }
}
