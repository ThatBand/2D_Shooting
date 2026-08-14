using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTutorialPattern : MonoBehaviour
{
    public Vector3[] targetPos;

    public int blueCount;
    public float radius;

    public EnemyData bossData;

    public Transform player;

    private List<EnemyBullet> bullets = new List<EnemyBullet>();

    private void OnEnable()
    {
        
    }

    private void Start()
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
        for (int i = 0; i < blueCount; i++)
        {
            float angle = (360f / blueCount) * i;

            float x = Mathf.Sin(Mathf.Deg2Rad * angle);
            float y = Mathf.Cos(Mathf.Deg2Rad * angle);

            Vector3 a = new Vector3((player.position.x + x * radius), (player.position.y + y * radius), 0);

            GameObject bullet = Instantiate(bossData.enemyBullet[4], a, Quaternion.identity);
            
            if (bullet.TryGetComponent(out EnemyBullet bulletSC))
            {
                bulletSC.Setup(EnemyBullet.bulletType.blue);
                bullets.Add(bulletSC);
            }

            yield return null;
        }

        foreach (EnemyBullet bullet in bullets)
        {
            bullet.MoveStart();
        }
    }

    //IEnumerator YellowBulletTutorial()
    //{

    //}
}
