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

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemyS());
    }

    IEnumerator SpawnEnemyS()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            float angle = i * Mathf.PI * 2 / enemyCount;

            Vector3 pos = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            Instantiate(enemy_S, pos, Quaternion.identity);

            yield return null;
        }

        //while (true)
        //{
        //    yield return new WaitForSeconds(1);

        //    if (enemy_S.TryGetComponent(out ShieldMinion enemySC) && enemySC.isFinish)
        //    {
        //        manager.ChangeState(BossState.Idle);
        //        yield break;
        //    }
        //}
    }
}
