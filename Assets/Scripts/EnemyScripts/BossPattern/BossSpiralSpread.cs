using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiralSpread : MonoBehaviour
{
    public Transform bulletContainer;
    public float RotateSpeed;

    public int bulletCount;
    public int bulletSpeed;
    public float fireTime;
    public EnemyData bossData;

    private void Start()
    {
        StartCoroutine(SprialBullet());
    }

    private void Update()
    {
        bulletContainer.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
    }

    IEnumerator SprialBullet()
    {
        while (true)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject bullet = Instantiate(bossData.enemyBullet[1], bulletContainer.position, Quaternion.identity, bulletContainer);
                Rigidbody2D bulletRigid = bullet.GetComponent<Rigidbody2D>();

                float a = (360f / bulletCount) * i + 1;
                bullet.transform.localRotation = Quaternion.Euler(0, 0, a);
                bulletRigid.AddForce(bullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(fireTime);
        }
    }
}
