using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InduceBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameManager.instance.player;
    }

    private void FixedUpdate()
    {
        Vector2 dir = (player.position - transform.position).normalized;

        float angle = Vector2.SignedAngle(transform.up, dir);

        float rotateAmount = Mathf.Clamp(angle, -100 * Time.fixedDeltaTime, 100 * Time.fixedDeltaTime);

        rigid.rotation += rotateAmount;

        rigid.velocity = transform.up * 3;
    }
}
