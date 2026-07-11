using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quartz : MonoBehaviour
{
    public Laser laserPrefab;
    private SpriteRenderer sprite;

    private Laser _spawnLaser = null;

    public float blinkCount;
    public float blinkSpeed;

    private bool isDestroying = false;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(QuartzLaser());
    }

    private void Update()
    {
        if (!isDestroying && _spawnLaser != null && _spawnLaser.isEnd)
        {
            isDestroying = true;
            Destroy(gameObject, 1);
        }
    }

    IEnumerator QuartzLaser()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            Color color = sprite.color;
            color.a = 0.5f;
            sprite.color = color;

            yield return new WaitForSeconds(blinkSpeed);

            color.a = 1;
            sprite.color = color;

            yield return new WaitForSeconds(blinkSpeed);
        }

        Vector3 targetPos = GameManager.instance.player.position;
        Vector3 dir = targetPos - transform.position;

        Laser spawnLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        _spawnLaser = spawnLaser;

        spawnLaser.transform.up = -dir;
        spawnLaser.Fire();

        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
    }

    //포폴 문제 해결
    //private void FireLaserAngle(float zAngle, Vector3 pos)
    //{
    //    Laser spawnLaser = Instantiate(laserPrefab, pos, Quaternion.Euler(0, 0, zAngle), transform);
    //    spawnLaser.Fire();
    //}
}
