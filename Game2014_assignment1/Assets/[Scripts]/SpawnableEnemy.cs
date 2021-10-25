
///
///Author: Andrew Boulanger 101292574
///
/// File: SpawnableEnemy.cs
/// 
/// Description: inherits from spawnable object class. returns itself to the pool when offscreen or destroyed
/// 
/// last Modified: Oct 24th 2021
///
/// version history: 
///     v1 created file from the spawnable object class and moved the take damage function here.
///     v2 plays explosion sound and animation when destroyed via damage
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// inherits from spawnable object class. returns itself to the pool when offscreen or destroyed
/// </summary>
public class SpawnableEnemy : SpawnableObject
{

    float currentDamage = 0;
    float maxDamage = 10;
    Timer damageTimer;
    float damageFrequency = 0.1f;
    int destructionScoreValue = 50;

    AudioClip explosionAudio;

    static SpawnableObjectFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        damageTimer = new Timer();

        explosionAudio = Resources.Load<AudioClip>("Audio/explosion");

        if(factory == null)
        {
            factory = FindObjectOfType<SpawnableObjectFactory>();
        }
    }


    protected override void OnDisable()
    {
        currentDamage = 0;
        hudDelegate = null;
    }

    public void TakeDamage(float damage)
    {
        if (damageTimer.IsTimerDone(damageFrequency))
        {
            currentDamage += damage;

            if (currentDamage >= maxDamage)
            {
                //spawn explosion
                if(factory != null)
                {
                    MusicPlayer.Instance().PlaySFX(explosionAudio);
                    factory.CreateSpawnableObject(SObjectType.Explosion, transform.position);
                }
                //remove from scene
                hudDelegate(HudFunctions.AddToScore, destructionScoreValue);
                owningPool.ReturnObject(gameObject);
            }
        }
    }
}
