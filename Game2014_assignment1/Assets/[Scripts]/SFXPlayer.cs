
///
///Author: Andrew Boulanger 101292574
///
/// File: SFXPlayer.cs
/// 
/// Description: used to return the Audio player back to the pool when not in use. 
/// 
/// last Modified: Oct 19th 2021
///
/// version history: 
///     v1 created file. checks if clip has ended and returns to the owning pool set by the music player
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// used to return the Audio player back to the pool when not in use.
/// </summary>
public class SFXPlayer : MonoBehaviour
{
    AudioSource audioSource;
    public ObjectPool owner = null;
    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.isPlaying == false && owner != null)
            owner.ReturnObject(gameObject);
    }
}
