using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private BossPatternManager manager;

    public Vector3 targetPos;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (transform.position.y >= targetPos.y)
        {
            transform.position += Vector3.down * 1.5f * Time.deltaTime;

            yield return null;
        }

        transform.position = targetPos;

        yield return new WaitForSeconds(1.5f);

        manager.ChangeState(BossState.Idle);
    }
}
