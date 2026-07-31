using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnShieldMinion : MonoBehaviour
{
    public GameObject enemy_S;

    [Header("설정 값")]
    public int enemyCount;
    public float radius;

    private BossPatternManager manager;

    private bool a;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        a = false;
        StartCoroutine(SpawnEnemyS());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnEnemyS()
    {
        List<ShieldMinion> spawnEnemy = new List<ShieldMinion>();

        for (int i = 0; i < enemyCount; i++)
        {
            float angle = i * Mathf.PI * 2 / enemyCount;
            Vector3 pos = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            GameObject enemy = Instantiate(enemy_S, pos, Quaternion.identity);

            if (enemy.TryGetComponent(out ShieldMinion enemySC))
                spawnEnemy.Add(enemySC);

            yield return null;
        }

        while (true)
        {
            yield return null;
            Debug.Log("while로 상태 체크 중");

            a = true;

            foreach (ShieldMinion minion in spawnEnemy)
            {
                if (minion != null && !minion.isFinish)
                {
                    Debug.Log("a");
                    a = false;
                    break;
                }
            }

            Debug.Log("b");
            if (a)
            {
                Debug.Log("Idle로 상태 전환!");
                manager.ChangeState(BossState.Idle);
                yield break;
            }
        }
    }
}
