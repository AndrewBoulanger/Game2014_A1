using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    SpawnableObjectFactory factory;

    List<SObjectType> objectsToSpawn = new List<SObjectType>()
    {
        SObjectType.Hole,
        SObjectType.Heart,
        SObjectType.S_Pickup,
        SObjectType.UFO,
        SObjectType.Zombie
    };

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

        factory = FindObjectOfType<SpawnableObjectFactory>();

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.IsTimerDone(spawnTime))
        {
            SpawnObject();
        }
        if (speedIncreaseTimer.IsTimerDone(speedIncreaseTime) && speedIncreaseTime > minSpawnTime)
        {
            RaiseSpeed();
        }
    }

    /// <summary>
    /// grab a random object from the factory and add it to the scene in a random row. 
    /// </summary>
    void SpawnObject()
    {
        SObjectType randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        Vector2 randomPos = startPositions[Random.Range(0, startPositions.Count)];

        factory.CreateSpawnableObject(randomObject, randomPos);
    }

    void RaiseSpeed()
    {
        speedIncreaseTime -= spawnSpeedIncrement;
    }
}
