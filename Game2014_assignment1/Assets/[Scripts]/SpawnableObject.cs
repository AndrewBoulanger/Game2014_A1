using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//component for objects that need to return to an object pool and have an effect when they collide with the player
public class SpawnableObject : MonoBehaviour
{
    private ObjectPool owningPool;

    private HudDelegate hudDelegate;

    public HudFunctions onCollisionEffect;
    public int changeToHudValue;

    public bool isRemovedOnCollision;

    public bool isDamageable;
    float currentDamage = 0;
    float maxDamage = 10;
    Timer damageTimer;
    float damageFrequency = 0.1f;
    int destructionScoreValue = 50;

    public AudioClip collisionAudioClip;

    public void SetHudAndOwnerData(ObjectPool owningPool, HudDelegate del)
    {
        this.owningPool = owningPool;
        hudDelegate = del;

        if (isDamageable)
            damageTimer = new Timer();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -ScreenSize.width)
        {
            owningPool.ReturnObject(gameObject);
        }

    }

    private void OnDisable()
    {
        currentDamage = 0;
        hudDelegate = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            hudDelegate(onCollisionEffect, changeToHudValue);

            if(collisionAudioClip != null)
                MusicPlayer.Instance().PlaySFX(collisionAudioClip);

            if(isRemovedOnCollision)
                owningPool.ReturnObject(gameObject);
        }

    }

    public void TakeDamage(float damage)
    {
        if(isDamageable && damageTimer.IsTimerDone(damageFrequency))
        {
            currentDamage += damage;

            if(currentDamage >= maxDamage)
            {
                //add explosion here

                hudDelegate(HudFunctions.AddToScore, destructionScoreValue);
                owningPool.ReturnObject(gameObject);
            }
        }
    }

}
