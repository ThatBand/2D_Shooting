using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBullet : MonoBehaviour
{
    public float speed;
    public Vector3 dir;

    public int bounceCount;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LaserWall"))
        {
            rigid.velocity = new Vector2(-rigid.velocity.x, rigid.velocity.y);

            bounceCount--;
        }

        else if (collision.CompareTag("CoreHit"))
        {
            if (collision.transform.parent.TryGetComponent(out PlayerHealth health))
                health.TakeDamage();

            Destroy(gameObject);
        }
    }
}
