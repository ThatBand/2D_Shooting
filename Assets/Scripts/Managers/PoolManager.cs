using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolInfo
{
    public string key;
    public GameObject prefab;
    public int initCount;
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public List<PoolInfo> poolInfos;

    private Dictionary<string, Queue<GameObject>> pools = new();

    private void Awake()
    {
        Instance = this;

        foreach (var info in poolInfos)
        {
            var queue = new Queue<GameObject>();

            for (int i = 0; i < info.initCount; i++)
            {
                var obj = Instantiate(info.prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            pools[info.key] = queue;
        }
    }

    public GameObject Get(string key, Vector3 pos, Quaternion rot)
    {
        if (!pools.TryGetValue(key, out var queue))
            return null;

        GameObject obj = queue.Count > 0 ? queue.Dequeue() : Instantiate(GetPrefab(key), transform);

        obj.transform.SetPositionAndRotation(pos, rot);
        obj.SetActive(true);
        return obj;
    }

    public void Return(string key, GameObject obj)
    {
        obj.SetActive(false);
        pools[key].Enqueue(obj);
    }

    GameObject GetPrefab(string key)
    {
        return poolInfos.Find(p => p.key == key).prefab;
    }
}
