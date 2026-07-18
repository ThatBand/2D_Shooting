using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPrisonDodge : MonoBehaviour
{
    public EnemyData bossData;

    [Header("총알 등장 확률")]
    public float red;
    public float blue;
    public float yellow;

    private int rand;

    [Header("발사 쿨타임")]
    public float fireRate;

    [Header("총알 속도")]
    public float bulletSpeed;

    private void OnEnable()
    {
        StartCoroutine(dodge());
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

    IEnumerator dodge()
    {
        for (int i = 0; i < 8; i++)
        {
            rand = Random.Range(0, 3);

            Vector3 bullet0Pos = Vector3.zero;
            Vector3 bullet1Pos = Vector3.zero;

            switch (rand)
            {
                case 0:
                    bullet0Pos = new Vector3(0, 1, 0);
                    bullet1Pos = new Vector3(1.3f, 1, 0);
                    break;
                case 1:
                    bullet0Pos = new Vector3(-1.3f, 1, 0);
                    bullet1Pos = new Vector3(1.3f, 1, 0);
                    break;
                case 2:
                    bullet0Pos = new Vector3(-1.3f, 1, 0);
                    bullet1Pos = new Vector3(0, 1, 0);
                    break;
            }

            GameObject bullet0 = Instantiate(bossData.enemyBullet[2], bullet0Pos, Quaternion.identity);
            GameObject bullet1 = Instantiate(bossData.enemyBullet[2], bullet1Pos, Quaternion.identity);

            EnemyBullet bulletSC0 = bullet0.GetComponent<EnemyBullet>();
            BulletProbability(bulletSC0);
            EnemyBullet bulletSC1 = bullet1.GetComponent<EnemyBullet>();
            BulletProbability(bulletSC1);

            Rigidbody2D rigid0 = bullet0.GetComponent<Rigidbody2D>();
            Rigidbody2D rigid1 = bullet1.GetComponent<Rigidbody2D>();

            rigid0.AddForce(Vector2.down * bulletSpeed);
            rigid1.AddForce(Vector2.down * bulletSpeed);

            yield return new WaitForSeconds(fireRate);
        }
    }
}
