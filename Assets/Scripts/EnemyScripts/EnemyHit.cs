using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public bool isBoss;

    public Sprite[] sprites;
    public Sprite flashSprite;

    private SpriteRenderer spriteRenderer;

    private Coroutine animCo;
    private Coroutine hitCo;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(AnimRoutine());
    }

    public void OnHit()
    {
        if (!isBoss)
        {
            spriteRenderer.sprite = sprites[1];

            Invoke("ReturnSprite", 0.1f);
        }

        else
        {
            if (hitCo != null)
                StopCoroutine(hitCo);

            hitCo = StartCoroutine(HitRoutine());
        }
    }

    IEnumerator AnimRoutine()
    {
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                spriteRenderer.sprite = sprites[i];

                yield return new WaitForSeconds(0.1f);
            }

            yield return null;
        }
    }

    IEnumerator HitRoutine()
    {
        if (animCo != null)
        {
            StopCoroutine(animCo);
            animCo = null;
        }

        spriteRenderer.sprite = sprites[0];
        yield return null;

        spriteRenderer.sprite = flashSprite;

        yield return new WaitForSeconds(0.5f);

        animCo = StartCoroutine(AnimRoutine());
        hitCo = null;
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
