using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float speed;
    public float height;

    public Vector3 targetPos;

    private Vector3 startPos;
    private EnemyHealth health;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = targetPos; 

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (transform.position.y >= targetPos.y)
        {
            transform.position += Vector3.down * 1.5f * Time.deltaTime;

            yield return null;
        }

        transform.position = targetPos;

        yield return new WaitForSeconds(1f);

        while (true)
        {
            transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * speed) * height;

            yield return null;
        }
    }
}
