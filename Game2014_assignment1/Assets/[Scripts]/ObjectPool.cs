using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public Queue<GameObject> objectPool;
   
    public int minPoolSize = 1;

    public GameObject objectToPool;

    public ObjectPool(GameObject objectToPool)
    {
        objectPool = new Queue<GameObject>();
        this.objectToPool = objectToPool;
    }

   

    protected virtual void AddObjectToPool()
    {
        GameObject newObject = GameObject.Instantiate<GameObject>(objectToPool);
        newObject.SetActive(false);
        objectPool.Enqueue(newObject);
    }

    public virtual GameObject GetObject(Vector2 spawnPosition)
    {
        if (objectPool.Count < minPoolSize)
        {
            for (int i = 0; i < minPoolSize; i++)
            {
                AddObjectToPool();
            }
        }

        var temp = objectPool.Dequeue();
        temp.transform.position = spawnPosition;
        temp.SetActive(true);
        return temp;
    }

    public void ReturnObject(GameObject returned_object)
    {
        returned_object.SetActive(false);
        objectPool.Enqueue(returned_object);
    }

}

