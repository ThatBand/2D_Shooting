using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerInvincibility : MonoBehaviour
{
    private bool isInvincibility;
    public bool IsInvincibility => isInvincibility;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        GetComponent<PlayerHealth>().OnDamaged += StartInvincibility;
    }

    void StartInvincibility()
    {
        StartCoroutine(BlinkPlayer());
    }

    IEnumerator BlinkPlayer()
    {
        if (isInvincibility)
            yield break;

        isInvincibility = true;

        Color defalutColor = sprite.color;
        Color alphaColor = sprite.color;
        alphaColor.a = 0.2f;

        for (int i = 0; i < 4; i++)
        {
            sprite.color = alphaColor;

            yield return new WaitForSeconds(0.2f);

            sprite.color = defalutColor;

            yield return new WaitForSeconds(0.8f);
        }

        isInvincibility = false;
    }
}
