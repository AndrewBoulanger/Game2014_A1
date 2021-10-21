using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameObjectsManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objectTypes;

    HudBehaviour hud;

    List<ObjectPool> objectPools;

    [SerializeField]
    List<Vector2> startPositions;

    Timer spawnTimer;
    float spawnTime = 1.5f;

    Timer speedIncreaseTimer;
    float speedIncreaseTime = 30f;
    float spawnSpeedIncrement = 0.25f;
    float minSpawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = new Timer();
        speedIncreaseTimer = new Timer();

        hud = FindObjectOfType<HudBehaviour>();
        objectPools = new List<ObjectPool>();
        foreach(GameObject obj in objectTypes)
        {
            ObjectPool newPool = new ObjectPool(obj);
            objectPools.Add(newPool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer.IsTimerDone(spawnTime))
        {
            SpawnObject();
        }
        if(speedIncreaseTimer.IsTimerDone(speedIncreaseTime) && speedIncreaseTime > minSpawnTime)
        {
            RaiseSpeed();
        }
    }

    /// <summary>
    /// creates a random object and adds it to the scene in a random row. Also checks to see if it has a spawnable object class 
    /// so it can pass in the hud and original pool. this lets it broadcast to the hub and return if destroyed/collected/offscreen
    /// </summary>
    void SpawnObject()
    {
        ObjectPool randomPool = objectPools[ Random.Range(0, objectPools.Count)]; 
        Vector2 randomPos = startPositions[Random.Range(0, startPositions.Count)];

        GameObject newObject = randomPool.GetObject(randomPos);
        SpawnableObject objectData = newObject.GetComponent<SpawnableObject>();
        
        if(objectData != null)
            objectData.SetHudAndOwnerData(randomPool, hud.hudDelegate);

    }

    void RaiseSpeed()
    {
        speedIncreaseTime -= spawnSpeedIncrement;
    }
}
