using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollow : MonoBehaviour
{
    public float followSpeed;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player != null)
            transform.position = Vector3.MoveTowards(
                                        transform.position, 
                                        GameManager.instance.player.position, 
                                        followSpeed * Time.deltaTime);
    }
}
