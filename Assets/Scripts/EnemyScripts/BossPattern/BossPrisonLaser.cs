using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrisonLaser : MonoBehaviour
{
    public Laser laserPrefab;

    public float laserPatternDelay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LaserPattern());
        }
    }

    IEnumerator LaserPattern()
    {
        FireLaserAngle(-90, new Vector2(6, -3));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(0, new Vector2(0, 7));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(-90, new Vector2(6, -2));
        FireLaserAngle(-90, new Vector2(6, -4));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(0, new Vector2(0, 7));
        FireLaserAngle(-90, new Vector2(6, -3));

        yield return new WaitForSeconds(laserPatternDelay);

        FireLaserAngle(45, new Vector2(-6, 3));
        FireLaserAngle(-45, new Vector2(6, 3));
    }

    private void FireLaserAngle(int zAngle, Vector3 pos)
    {
        Laser spawnLaser = Instantiate(laserPrefab, pos, Quaternion.Euler(0, 0, zAngle));
        spawnLaser.Fire();
    }
}