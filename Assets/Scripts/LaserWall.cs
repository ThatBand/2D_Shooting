using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserWall : MonoBehaviour
{
    public EnemyData data;

    public float speed;

    public float targetY;

    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    public bool isFinish;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        speed = data.speed;
    }

    private void Start()
    {
        StartCoroutine(Laser());
    }

    private void OnDisable()
    {
        isFinish = false;
    }

    IEnumerator Laser()
    {
        Vector2 newSize = sprite.size;

        while (newSize.y < targetY)
        {
            newSize.y += speed * Time.deltaTime;
            sprite.size = newSize;

            coll.size = newSize;
            coll.offset = new Vector2(0, -newSize.y / 2);

            yield return null;
        }

        coll.size = newSize;
        isFinish = true;
    }
}
