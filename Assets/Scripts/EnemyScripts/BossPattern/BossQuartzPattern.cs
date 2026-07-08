using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossQuartzPattern : MonoBehaviour
{
    public Quartz quartzPrefab;

    public int quartzCount;
    public Vector2 creationCycle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateQuartz());
    }

    IEnumerator GenerateQuartz()
    {
        for (int i = 0; i < quartzCount; i++)
        {
            float randX = Random.Range(-5f, 5f);
            float randY = Random.Range(0f, -5.5f);

            float randCycle = Random.Range((float)creationCycle.x, (float)creationCycle.y);

            Instantiate(quartzPrefab, new Vector2(randX, randY), Quaternion.identity);

            yield return new WaitForSeconds(randCycle);
        }
    }
}
