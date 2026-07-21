using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossQuartzPattern : MonoBehaviour
{
    public Quartz quartzPrefab;

    public int quartzCount;
    public Vector2 creationCycle;

    public List<Quartz> spawnedQuartzList = new List<Quartz>();

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(GenerateQuartz());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator GenerateQuartz()
    {
        for (int i = 0; i < quartzCount; i++)
        {
            float randX = Random.Range(-5f, 5f);
            float randY = Random.Range(0f, -5.5f);

            float randCycle = Random.Range((float)creationCycle.x, (float)creationCycle.y);

            Quartz spawnQ = Instantiate(quartzPrefab, new Vector2(randX, randY), Quaternion.identity);
            spawnedQuartzList.Add(spawnQ);

            yield return new WaitForSeconds(randCycle);
        }

        while (true)
        {
            bool isAllDestroyed = true;

            foreach (Quartz q in spawnedQuartzList)
            {
                if (q != null)
                {
                    isAllDestroyed = false;
                    break;
                }
            }

            if (isAllDestroyed)
                break;

            yield return null;
        }

        manager?.ChangeState(BossState.Idle);
    }
}
