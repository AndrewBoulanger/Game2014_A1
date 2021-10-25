
///
///Author: Andrew Boulanger 101292574
///
/// File: SpawnableObjectFactory.cs
/// 
/// Description: returns a specified object, given the SObject type. also gives the object a hud delegate and the owning pool 
///     so it can contact the hud and return to the pool when done. uses the object pool class
/// 
/// last Modified: Oct 24th 2021
///
/// version history: 
///     v1 created to make spawning objects simpler
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SObjectType
{
    UFO, Zombie, S_Pickup, Heart, Hole, Explosion, Laser 
    
    
}

/*returns a specified object, given the SObject type. also gives the object a hud delegate and the owning pool
//so it can contact the hud and return to the pool when done.  uses the object pool class*/
public class SpawnableObjectFactory : MonoBehaviour
{
    HudBehaviour hud;

    [SerializeField]
    List<GameObject> objectPrefabs;
    
    List<ObjectPool> objectPools;


    // Start is called before the first frame update
    void Start()
    {
        hud = FindObjectOfType<HudBehaviour>();

        objectPools = new List<ObjectPool>();
        foreach (GameObject obj in objectPrefabs)
        {
            ObjectPool newPool = new ObjectPool(obj);
            objectPools.Add(newPool);
        }
    }

    //returns the specified spawnable object to the given location. sets the hud delegate and owing pool as well
    public GameObject CreateSpawnableObject(SObjectType type, Vector2 location)
    {
        GameObject newObject = objectPools[(int)type].GetObject(location);

        SpawnableObject spawnable = newObject.GetComponent<SpawnableObject>();

        if(spawnable != null)
        { 
            spawnable.SetHudDelegate(hud.hudDelegate);
            spawnable.SetOwnerData(objectPools[(int)type]);
        }

        return newObject;
    }
}
