using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject boomEffect;

    public void OnBoomEffect()
    {
        boomEffect.SetActive(true);

        Invoke("OffBoomEffect", 5f);
    }

    void OffBoomEffect()
    {
        boomEffect.SetActive(false);
    }
}
