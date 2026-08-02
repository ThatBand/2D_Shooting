using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBullet : MonoBehaviour
{
    public float speed;
    public Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    public void Shot(Vector3 dir)
    {
        this.dir = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LaserWall"))
        {
            transform.localScale += Vector3.one * 0.5f;
            dir.x *= -1;
        }

        else if (collision.CompareTag("CoreHit"))
        {
            if (collision.transform.parent.TryGetComponent(out PlayerHealth health))
                health.TakeDamage();

            Destroy(gameObject);
        }
    }
}
