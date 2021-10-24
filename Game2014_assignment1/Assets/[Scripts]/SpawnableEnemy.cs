using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
