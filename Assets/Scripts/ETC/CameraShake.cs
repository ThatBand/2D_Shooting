using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    public void Shake(float dur, float mag)
    {
        StartCoroutine(ShakeCoroutine(dur, mag));
    }

    IEnumerator ShakeCoroutine(float dur, float mag)
    {
        Vector3 originPos = transform.position;
        float elapsed = 0;

        while (elapsed < dur)
        {
            float x = Random.Range(-1, 1) * mag;
            float y = Random.Range(-1, 1) * mag;

            transform.localPosition = new Vector3(originPos.x + x, originPos.y + y, originPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originPos;
    }
}
