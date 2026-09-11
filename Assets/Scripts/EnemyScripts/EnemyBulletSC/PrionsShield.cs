using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PrionsShield : MonoBehaviour
{
    [Header("쉴드 회전 속도")]
    public float rotationSpeed;

    public void RotationShield()
    {
        StartCoroutine(RotatShield());
    }

    IEnumerator RotatShield()
    {
        while (true)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
            Destroy(collision.gameObject);
    }
}
