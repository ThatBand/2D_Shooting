using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private float jumpVelocity = 4;
    private float gravity = 3;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.up * jumpVelocity;
    }

    private void Update()
    {
        dir.y -= gravity * Time.deltaTime;

        transform.position += dir * Time.deltaTime;
    }
}
