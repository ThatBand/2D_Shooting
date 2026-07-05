using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class btr : MonoBehaviour
{
    public TextMeshPro text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(text, new Vector3(2.5f, 3, 0), Quaternion.identity);
        }
    }
}
