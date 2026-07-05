using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Vector2 dir;

    private Rigidbody2D rigid;
    private Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, -5.5f, 5.5f),
                                              Mathf.Clamp(rigid.position.y, -6.5f, 6.5f),
                                              0);

        rigid.velocity = (dir.normalized) * speed;
    }

    private void LateUpdate()
    {
        anim.SetInteger("move", (int)dir.x);
    }
}