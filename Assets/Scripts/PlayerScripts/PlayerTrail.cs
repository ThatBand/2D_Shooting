using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public float interval;
    public float dur;
    public Color color = new Color(0.5f, 0.5f, 1, 0.35f);

    private SpriteRenderer sprite;
    private Coroutine trailCoroutine;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void StartTrail()
    {
        if (trailCoroutine == null)
            trailCoroutine = StartCoroutine(SpawnTrailRoutine());
    }

    public void StopTrail()
    {
        if (trailCoroutine != null)
        {
            StopCoroutine(trailCoroutine);
            trailCoroutine = null;
        }
    }

    private IEnumerator SpawnTrailRoutine()
    {
        while (true)
        {
            SpawnGhost();
            yield return new WaitForSeconds(interval);
        }
    }

    private void SpawnGhost()
    {
        GameObject ghost = new GameObject("PlayerGhost");

        ghost.transform.position = transform.position;

        SpriteRenderer ghostSprite = ghost.AddComponent<SpriteRenderer>();
        ghostSprite.sprite = sprite.sprite;
        ghostSprite.sortingLayerID = sprite.sortingLayerID;
        ghostSprite.sortingOrder = sprite.sortingOrder - 1;
        ghostSprite.color = color;

        StartCoroutine(FadeAndDestroy(ghost, ghostSprite));
    }

    private IEnumerator FadeAndDestroy(GameObject a, SpriteRenderer sr)
    {
        float timer = 0;
        Color startColor = sr.color;

        while (timer < dur)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 0, timer / dur);
            sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            yield return null;
        }

        Destroy(a);
    }
}
