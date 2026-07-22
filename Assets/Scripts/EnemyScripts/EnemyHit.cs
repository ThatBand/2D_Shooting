using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public bool isBoss;

    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    public Animator anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            anim.SetTrigger("isHit");
            SoundManager.instance.BossHitSound();
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
