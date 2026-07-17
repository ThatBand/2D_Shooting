using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMakePrison : MonoBehaviour
{
    public GameObject prison;
    public Vector3 targetVec;
    public float speed;

    private bool isShrinking;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
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
    }

    //void Update()
    //{
    //    if (isShrinking)
    //    {
    //        prison.transform.localScale = Vector3.MoveTowards(prison.transform.localScale, Vector3.one, 1.5f * Time.deltaTime);

    //        if (prison.transform.localScale == Vector3.one)
    //            isShrinking = false;
    //    }

    //    manager.ChangeState(BossState.Idle);
    //}
}
