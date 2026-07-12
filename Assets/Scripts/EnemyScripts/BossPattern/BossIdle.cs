using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : MonoBehaviour
{
    public float speed;
    public float height;
    public float idleTime;

    private BossPatternManager manager;
    private Vector3 startPos;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        startPos = transform.position;

        StartCoroutine(Idle());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Idle()
    {
        float elapsedTime = 0;

        while (elapsedTime < idleTime)
        {
            elapsedTime += Time.deltaTime;

            transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * speed) * height;

            yield return null;
        }

        manager.ExecuteNextPattern();
    }
}
