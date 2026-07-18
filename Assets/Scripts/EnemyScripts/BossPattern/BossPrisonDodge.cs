using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPrisonDodge : MonoBehaviour
{
    public EnemyData bossData;

    public int randNum;
    public float fireRate;
    public float bulletSpeed;

    private void OnEnable()
    {
        StartCoroutine(dodge());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator dodge()
    {
        for (int i = 0; i < 8; i++)
        {
            randNum = Random.Range(0, 3);

            Vector3 bullet0Pos = Vector3.zero;
            Vector3 bullet1Pos = Vector3.zero;

            switch (randNum)
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

            //EnemyBullet bulletSC0 = bullet0.GetComponent<EnemyBullet>();
            //bulletSC0.Setup(EnemyBullet.bulletType.red);
            //EnemyBullet bulletSC1 = bullet1.GetComponent<EnemyBullet>();
            //bulletSC1.Setup(EnemyBullet.bulletType.red);

            Rigidbody2D rigid0 = bullet0.GetComponent<Rigidbody2D>();
            Rigidbody2D rigid1 = bullet1.GetComponent<Rigidbody2D>();

            rigid0.AddForce(Vector2.down * bulletSpeed);
            rigid1.AddForce(Vector2.down * bulletSpeed);

            yield return new WaitForSeconds(fireRate);
        }
    }
}
