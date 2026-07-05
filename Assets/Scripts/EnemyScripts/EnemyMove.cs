using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public bool isStop;

    public EnemyData enemyData;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isStop)
            rigid.velocity = Vector2.zero;

        else
            rigid.velocity = Vector2.down * enemyData.speed;
    }
}
