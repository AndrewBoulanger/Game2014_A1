
///
///Author: Andrew Boulanger 101292574
///
/// File: SpawnableObject.cs
/// 
/// Description: returns itself to the pool when offscreen. Used for any object that needs to be spawned in and might collide with the player 
///     Has a hud delegate used to tell the hud how to react when the player is hit. These objects are created by the spawnable object factory. 
///     acts as a base class for spawnable enemy and spawnable animation.
/// 
/// last Modified: Oct 24th 2021
///
/// version history: 
///     v1 created file from the spawnable object class with hud delegate and collision effects. checks for collision with player or going off screen
///     v2 modified to include enemies and animations, then broken apart with inheritance.
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//component for objects that need to return to an object pool and have an effect when they collide with the player
public class SpawnableObject : MonoBehaviour
{
    protected ObjectPool owningPool;

    protected HudDelegate hudDelegate;

    public HudFunctions onCollisionEffect;
    public int changeToHudValue;

    public bool isRemovedOnCollision;

    public AudioClip collisionAudioClip;


    public void SetOwnerData(ObjectPool owningPool)
    {
        this.owningPool = owningPool;
    }
    public void SetHudDelegate(HudDelegate del)
    {
        hudDelegate = del;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -ScreenSize.width)
        {
            owningPool.ReturnObject(gameObject);
        }

    }

    protected virtual void OnDisable()
    {
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

}

