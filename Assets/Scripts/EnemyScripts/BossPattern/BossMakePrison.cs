using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMakePrison : MonoBehaviour
{
    public GameObject prison;

    private bool isShrinking;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            prison.SetActive(true);
            isShrinking = true;
        }

        if (isShrinking)
        {
            prison.transform.localScale = Vector3.MoveTowards(prison.transform.localScale, Vector3.one, 1.5f * Time.deltaTime);

            if (prison.transform.localScale == Vector3.one)
                isShrinking = false;
        }
    }
}
