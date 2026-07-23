using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBulletText : MonoBehaviour
{
    public ItemData scoreData;

    public float speed;
    public float alphaSpeed;
    public float destroyTime;

    private TextMeshPro tmp;
    private Color textColor;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    public void Setup()
    {
        tmp.text = scoreData.amount.ToString();

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
