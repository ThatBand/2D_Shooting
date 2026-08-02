using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class btr : MonoBehaviour
{
    public GameObject enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(enemy, new Vector2(0, 5.5f), Quaternion.identity);
    }
}
