using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    public bool isDestroy;

    public string poolName;

    protected Rigidbody2D rigid;
    private Coroutine destroyRoutine;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        if (isDestroy)
            Destroy(gameObject, 10f);
    }

    //protected virtual void OnEnable()
    //{
    //    if (isDestroy)
    //        destroyRoutine = StartCoroutine(ReturnAfterTime(10));
    //}

    //protected virtual void OnDisable()
    //{
    //    if (destroyRoutine != null)
    //    {
    //        StopCoroutine(destroyRoutine);
    //        destroyRoutine = null;
    //    }

    //    if (rigid != null)
    //        rigid.velocity = Vector2.zero;
    //}

    //IEnumerator ReturnAfterTime(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    PoolManager.Instance.Return(poolName, gameObject);
    //}
}