using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public float speed;
    public float alphaSpeed;
    public float destroyTime;

    private TextMeshPro tmp;
    private Color textColor;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    public void Setup(float dmg, bool isCrit)
    {
        tmp.text = dmg.ToString();

        if (isCrit)
        {
            tmp.color = Color.red;
            tmp.fontSize = 8;
        }

        else
        {
            tmp.color = Color.white;
            tmp.fontSize = 5;
        }

        textColor = tmp.color;
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

        textColor.a = Mathf.Lerp(textColor.a, 0, Time.deltaTime * alphaSpeed);
        tmp.color = textColor;
    }
}
