using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour
{
    public float speed;

    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newSize = sprite.size;
        newSize.y += speed * Time.deltaTime;
        sprite.size = newSize;

        coll.size = newSize;
    }
}
