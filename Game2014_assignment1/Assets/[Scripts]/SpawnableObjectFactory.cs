using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SObjectType
{
    UFO, Zombie, S_Pickup, Heart, Hole, Explosion, Laser 
    
    
}
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
