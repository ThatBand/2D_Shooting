using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet") || collision.CompareTag("PlayerBullet") || collision.CompareTag("Item"))
            Destroy(collision.gameObject);
    }
}
