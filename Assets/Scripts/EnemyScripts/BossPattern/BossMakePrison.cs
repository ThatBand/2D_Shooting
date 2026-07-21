using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMakePrison : MonoBehaviour
{
    public GameObject prison;
    public Vector3 targetVec;
    public float speed;

    private BossPatternManager manager;
    private EnemyHealth health;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
        health = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        prison.SetActive(true);
        StartCoroutine(Prison());
    }

    IEnumerator Prison()
    {
        health.isInvin = true;

        if (GameManager.instance.player.TryGetComponent(out PlayerRespawn respawn))
            respawn.RespawnPlayer();

        while (prison.transform.localScale != targetVec)
        {
            Debug.Log("감옥 축소 시작");
            prison.transform.localScale = Vector3.MoveTowards(prison.transform.localScale, targetVec, speed * Time.deltaTime);

            yield return null;
        }

        prison.transform.localScale = targetVec;
        health.isInvin = false;
        manager.ChangeState(BossState.Idle);
    }
}
