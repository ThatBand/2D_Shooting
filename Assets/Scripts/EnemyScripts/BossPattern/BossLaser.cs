using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public Laser[] lasers;
    public Transform laserRoot;

    private bool isRot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].Fire();
            }

            StartCoroutine(LaserRotPattern());
        }
    }

    IEnumerator LaserRotPattern()
    {
        if (isRot)
            yield break;

        isRot = true;

        yield return new WaitForSeconds(4);

        float z = 0;
        while (z < 80)
        {
            z += 20 * Time.deltaTime;
            laserRoot.rotation = Quaternion.Euler(0, 0, z);

            yield return null;
        }

        yield return new WaitForSeconds(2);

        while (z > -30)
        {
            z -= 20 * Time.deltaTime;
            laserRoot.rotation = Quaternion.Euler(0, 0, z);

            yield return null;
        }

        yield return new WaitForSeconds(2);

        while (z < 0.1)
        {
            z += 20 * Time.deltaTime;
            laserRoot.rotation = Quaternion.Euler(0, 0, z);

            yield return null;
        }

        isRot = false;

        yield return new WaitForSeconds(2);

        laserRoot.gameObject.SetActive(false);
    }
}
