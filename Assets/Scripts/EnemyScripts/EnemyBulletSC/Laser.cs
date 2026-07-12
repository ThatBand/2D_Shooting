using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float laserFireTime;
    public Transform laser;
    public GameObject warningLine;

    public bool isHide = false;
    public bool isEnd;

    public float warningTime;

    public bool isDestroy;

    public void Fire()
    {
        isEnd = false;
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        warningLine.SetActive(true);

        yield return new WaitForSeconds(warningTime);

        warningLine.SetActive(false);

        Vector3 start = new Vector3(1, 0f, 1);
        Vector3 end = new Vector3(1, 15, 1);

        float duration = 0.15f;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;

            float progress = t / duration;

            laser.localScale = Vector3.Lerp(start, end, progress);

            yield return null;
        }

        laser.localScale = end;

        yield return new WaitForSeconds(2);

        isEnd = true;

        if (isDestroy)
            Destroy(gameObject);
            //gameObject.SetActive(false);
    }
}