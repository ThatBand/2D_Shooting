using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBlossomingPattern : MonoBehaviour
{
    [Header("보스 데이터")]
    public EnemyData bossData;

    [Header("생성할 총알의 X 위치")]
    public float minPos;
    public float maxPos;

    [Header("생성할 총알의 Y 위치")]
    public float yPos;

    [Header("패턴 횟수 / 쿨타임")]
    public int patternCount;
    public float patternCoolTime;

    [Header("패턴 설정")]
    public int petalCount;

    public GameObject petal;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(BlossomSpawner());
    }

    private int activePetal = 0;

    IEnumerator BlossomSpawner()
    {
        activePetal = 0;

        for (int i = 0; i < patternCount; i++)
        {
            GameObject bullet = Instantiate(bossData.enemyBullet[5], new Vector3(Random.Range(minPos, maxPos), yPos, 0), Quaternion.identity);
            SoundManager.instance.BossShotSound_0();

            activePetal++;
            StartCoroutine(BlossomBullet(bullet));

            yield return new WaitForSeconds(patternCoolTime);
        }

        yield return new WaitUntil(() => activePetal == 0);

        manager.ChangeState(BossState.Idle);
    }

    IEnumerator BlossomBullet(GameObject bullet)
    {
        if (bullet.TryGetComponent(out Rigidbody2D rigid))
            rigid.angularVelocity = 50;

        float fallTime = Random.Range(1.5f, 2.5f);
        float timer = 0;

        while (timer < fallTime)
        {
            if (bullet == null)
                break;

            timer += Time.deltaTime;

            float a = Random.Range(0.5f, 2);
            float waveX = Mathf.Sin(timer * 6) * a;

            rigid.velocity = new Vector2(waveX, -3);

            yield return null;
        }

        rigid.velocity = Vector2.zero;

        bullet.transform.rotation = Quaternion.identity;

        GameObject[] spawnedPetals = new GameObject[petalCount];
        for (int k = 0; k < petalCount; k++)
        {
            float a = (360f / petalCount) * k;
            Vector3 offset = Quaternion.Euler(0, 0, a) * Vector3.up * 0.5f;

            spawnedPetals[k] = Instantiate(petal, bullet.transform.position + offset, Quaternion.Euler(0, 0, a), bullet.transform);
        }

        SoundManager.instance.BlossomBulletSound();

        float bloomTime = Random.Range(1.5f, 3.5f);
        yield return new WaitForSeconds(bloomTime);

        Transform player = GameManager.instance.player;

        Vector2 dir = player.position - bullet.transform.position;
        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, targetAngle);

        rigid.angularVelocity = 0;

        foreach (var petal in spawnedPetals)
        {
            if (petal.TryGetComponent(out Rigidbody2D petalRigid))
            {
                petal.transform.SetParent(null);
                Vector2 dir_ = (petal.transform.position - bullet.transform.position).normalized;
                petalRigid.velocity = dir_ * 6;
            }
        }

        Destroy(bullet);

        yield return new WaitUntil(() => System.Array.TrueForAll(spawnedPetals, petal => petal == null));
        activePetal--;
    }
}
