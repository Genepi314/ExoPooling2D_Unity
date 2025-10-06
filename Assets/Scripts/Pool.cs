using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Pool<T>
where T : IPoolClient
{
    private GameObject anchor;
    private GameObject prefab;
    private Queue<T> queue = new();
    private int batch;

    public Pool(GameObject anchor, GameObject prefab, int batch)
    {
        this.anchor = anchor;
        this.prefab = prefab;
        this.batch = batch;

        CreateBatch();
    }

    private void CreateBatch()
    {
        for (int _ = 0; _ < batch; _++)
        {
            GameObject go = GameObject.Instantiate(prefab);
            if (go.TryGetComponent(out T client))
            {
                Add(client);
            }
            else
            {
                throw new ArgumentException("Prefab doesn't implement IPoolClient");
            }
        }
    }

    public void Add(T client)
    {
        queue.Enqueue(client);
        client.Fall();
    }

    // public T Get()
    // {
    //     if (queue.Count == 0) CreateBatch();
    //     T client = queue.Dequeue();
    //     client.Arise(anchor.transform.position, anchor.transform.rotation);
    //     return client;
    // }



    public T Get(float minY, float maxY)
    {
        if (queue.Count == 0) CreateBatch();
        T client = queue.Dequeue();
        UnityEngine.Vector2 randomPosition = new UnityEngine.Vector2(anchor.transform.position.x, UnityEngine.Random.Range(minY, maxY));
        client.Arise(randomPosition, anchor.transform.rotation);
        return client;
    }

}
