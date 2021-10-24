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

