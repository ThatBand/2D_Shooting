using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrisonLaser : MonoBehaviour
{
    public Laser laserPrefab;
    public Laser activeLaser;

    public float laserPatternDelay;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(LaserPattern());
    }

    private void OnDisable()
    {
        Destroy(activeLaser.gameObject);
        StopAllCoroutines();
    }

    IEnumerator LaserPattern()
    {
        FireLaserAngle(-90, new Vector2(9, -3));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(0, new Vector2(0, 9));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(-90, new Vector2(8, -2));
        FireLaserAngle(-90, new Vector2(8, -4));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(0, new Vector2(0, 8));
        FireLaserAngle(-90, new Vector2(9, -3));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(45, new Vector2(-7, 4));
        FireLaserAngle(-45, new Vector2(7, 4));

        yield return new WaitForSeconds(laserPatternDelay);

        manager.ChangeState(BossState.Idle);
    }

    private void FireLaserAngle(int zAngle, Vector3 pos)
    {
        activeLaser = Instantiate(laserPrefab, pos, Quaternion.Euler(0, 0, zAngle));
        activeLaser.Fire();
    }
}