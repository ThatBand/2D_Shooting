using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    public bool isDestroy;

    protected Rigidbody2D rigid;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        if (isDestroy)
            Destroy(gameObject, 10f);
    }
}