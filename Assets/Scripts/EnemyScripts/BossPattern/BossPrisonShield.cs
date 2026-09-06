using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrisonShield : MonoBehaviour
{
    [Header("쉴드 오브젝트")]
    public GameObject shield;

    private void OnEnable()
    {
        shield.SetActive(true);
    }
}
