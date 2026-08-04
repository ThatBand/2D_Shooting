using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [Header("레이저, 안전 구역 프리팹")]
    public GameObject leftLaser;
    public GameObject rightLaser;

    public GameObject safeZone;

    [Header("설정 값")]
    public float minX;
    public float maxX;

    private float randNum;

    private BossPatternManager manager;

    private void Awake()
    {
        manager = GetComponent<BossPatternManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(SafeLaserPattern());
    }

    IEnumerator SafeLaserPattern()
    {
        for (int i = 0; i < 3; i++)
        {
            randNum = Random.Range(-4f, 4f);

            yield return new WaitForSeconds(3);

            GameObject safe = Instantiate(safeZone, new Vector3(randNum, 7.5f, 0), Quaternion.identity);

            float safeLeft = randNum - 0.5f;
            float safeRight = randNum + 0.5f;

            float leftLaserWidth = safeLeft - minX;
            float leftLaserPosX = minX + (leftLaserWidth / 2);

            GameObject laser_L = Instantiate(leftLaser, new Vector3(leftLaserPosX, 7.5f, 0), Quaternion.identity);
            laser_L.transform.localScale = new Vector3(leftLaserWidth, 1, 0);

            float rightLaserWidth = maxX - safeRight;
            float rightLaserPosX = safeRight + (rightLaserWidth / 2);

            GameObject laser_R = Instantiate(leftLaser, new Vector3(rightLaserPosX, 7.5f, 0), Quaternion.identity);
            laser_R.transform.localScale = new Vector3(rightLaserWidth, 1, 0);

            yield return new WaitForSeconds(0.5f);

            if (laser_L.TryGetComponent(out Laser laser_Lsc) && laser_R.TryGetComponent(out Laser laser_Rsc))
            {
                laser_Lsc.Fire();
                laser_Rsc.Fire();
            }

            while (true)
            {
                yield return null;

                if (laser_Lsc.isEnd)
                {
                    Destroy(safe);
                    break;
                }
            }
        }

        manager.ChangeState(BossState.Idle);
    }
}
