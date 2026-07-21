using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObj : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CoreHit"))
        {
            if (collision.transform.parent.TryGetComponent(out PlayerHealth player))
                player.TakeDamage();
        }
    }
}
