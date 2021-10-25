
///
///Author: Andrew Boulanger 101292574
///
/// File: objectPool.cs
/// 
/// Description: acts as a template to create various pools for various game objects. used by the music player and object factory
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 added the ability to create a pool, get an object and return it, objects are created dynamically
///     v2 removed monobehaviour
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///acts as a template to create various pools for various game objects
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

   
    //create object if needed
    protected virtual void AddObjectToPool()
    {
        GameObject newObject = GameObject.Instantiate<GameObject>(objectToPool);
        newObject.SetActive(false);
        objectPool.Enqueue(newObject);
    }

    //adds an object to the scene at the position specified, set it to active
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

    //deactivates an object and returns it to the pool
    public void ReturnObject(GameObject returned_object)
    {
        returned_object.SetActive(false);
        objectPool.Enqueue(returned_object);
    }

}

