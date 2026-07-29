using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMinion : MonoBehaviour
{
    [Header("설정값")]
    public float orbitSpeed;
    public float chargeSpeed;
    public float waitTime;

    private Transform boss;
    private Transform player;

    private bool isCharging;
    public bool isFinish;
    private Vector3 playerDir;

    private void OnEnable()
    {
        boss = GameManager.instance.boss;
        player = GameManager.instance.player;

        isCharging = false;
        isFinish = false;

        StartCoroutine(MinionPatternRoutine());
    }

    IEnumerator MinionPatternRoutine()
    {
        yield return new WaitForSeconds(waitTime);

        if (player != null)
            playerDir = (player.position - transform.position).normalized;

        else
            playerDir = Vector3.down;

        isCharging = true;

        yield return new WaitForSeconds(5);

        isFinish = true;
    }

    private void Update()
    {
        if (!isCharging)
        {
            if (boss != null)
            {
                transform.RotateAround(boss.position, Vector3.forward, orbitSpeed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }
        }

        else
            transform.Translate(playerDir * chargeSpeed * Time.deltaTime, Space.World);
    }
}
