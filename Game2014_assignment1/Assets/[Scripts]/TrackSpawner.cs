
///
///Author: Andrew Boulanger 101292574
///
/// File: TrackSpawner.cs
/// 
/// Description: randomly spawns enemies, hazards and pickups on one of the three rows in the game scene
/// 
/// last Modified: Oct 24th 2021
///
/// version history: 
///     v1 started as a game object manager with an object pool for each spawnable object
///     v2 moved object collection to the factory, now this class just chooses what to spawn and where.
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// randomly spawns enemies, hazards and pickups on one of the three rows in the game scene
/// </summary>
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

    //increases how often objects are spawned in
    void RaiseSpeed()
    {
        speedIncreaseTime -= spawnSpeedIncrement;
    }
}
