using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBullet : MonoBehaviour
{
    public Vector3 maxScale;
    public bool isCharging = true;

    private float time;

    public BulletData bulletData;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Charging());
    }

    IEnumerator Charging()
    {
        while (time < 2.5f)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, maxScale, time / 2.5f);

            time += Time.deltaTime;

            yield return null;
        }

        transform.localScale = maxScale;
        isCharging = false;

        Fire();
    }

    void Fire()
    {
        Vector3 dir = GameManager.instance.player.position - transform.position;
        rigid.AddForce(dir.normalized * bulletData.speed, ForceMode2D.Impulse);
    }
}
