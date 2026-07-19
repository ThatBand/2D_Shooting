using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMakePrison : MonoBehaviour
{
    public GameObject prison;
    public Vector3 targetVec;
    public float speed;

    public Collider2D bodyColl;
    public Collider2D weakColl;

    private bool isShrinking;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        bodyColl.enabled = false;
        weakColl.enabled = false;

        prison.SetActive(true);
        StartCoroutine(Prison());
    }

    IEnumerator Prison()
    {
        while (prison.transform.localScale != targetVec)
        {
            Debug.Log("감옥 축소 시작");
            prison.transform.localScale = Vector3.MoveTowards(prison.transform.localScale, targetVec, speed * Time.deltaTime);

            yield return null;
        }

        prison.transform.localScale = targetVec;
        manager.ChangeState(BossState.Idle);

        bodyColl.enabled = true;
        weakColl.enabled = true;
    }
}
