using System.Collections.Generic;
using UnityEngine;

public class Pooling : Singleton<Pooling>
{
    public GameObject poolPrefab;

    private Queue<GameObject> poolingQueue = new Queue<GameObject>();

    private void Awake()
    {
        Init(10);   
    }

    void Init(int count)
    {
        for (int i = 0; i < count; i++)
        {
            poolingQueue.Enqueue(CreateObject());
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.transform.SetParent(this.gameObject.transform, true);
        obj.SetActive(false);
        poolingQueue.Enqueue(obj);
    }

    public GameObject CreateObject()
    {
        var obj = Instantiate(poolPrefab, transform);
        obj.gameObject.SetActive(false);
        return obj;
    }

    public GameObject GetObject()
    {
        if (poolingQueue.Count > 0)
        {
            var obj = poolingQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            return obj;
        }
        else
        {
            var obj = CreateObject();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            return obj;
        }
    } 
}
