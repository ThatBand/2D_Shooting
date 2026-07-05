using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeBullet : MonoBehaviour
{
    public BulletData data;
    private Rigidbody2D rigid;
    private Transform player;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameManager.instance.player.transform;
    }

    public void Fire()
    {
        Vector3 dir = player.position - transform.position;
        transform.up = -dir;
        rigid.AddForce(dir.normalized * data.speed, ForceMode2D.Impulse);
    }
}
