using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserWallPattern : MonoBehaviour
{
    public EnemyData data;

    public GameObject enemy_L;

    public Vector2[] targetPos;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(MakeEnemy());
    }

    IEnumerator MakeEnemy()
    {
        for (int i = 0; i < targetPos.Length; i++)
        {
            yield return null;

            GameObject enemy = Instantiate(enemy_L, targetPos[i], Quaternion.identity);
        }

        yield return new WaitForSeconds(5);

        GameObject bullet = Instantiate(data.enemyBullet[5], transform.position, Quaternion.identity);
        Debug.Log("총알 생성");

        if (bullet.TryGetComponent(out PinballBullet pinball))
            pinball.Shot(Vector2.left);
    }
}
