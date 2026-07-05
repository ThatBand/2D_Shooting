using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= -9)
            transform.position = new Vector3(0, transform.position.y + 20, 0);
    }
}
