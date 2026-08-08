using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBody : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GrazeHit"))
        {
            if (collision.transform.parent.TryGetComponent(out PlayerHealth health))
                health.TakeDamage();
        }
    }
}
