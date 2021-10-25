
///
///Author: Andrew Boulanger 101292574
///
/// File: SpawnableAnimation.cs
/// 
/// Description: inherits from spawnable object class. returns itself to the pool when the animation ends
/// 
/// last Modified: Oct 24th 2021
///
/// version history: 
///     v1 created file. uses animator animation states to see if its idle, returns itself to the pool if it is.
///     only used by the explosion for now
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// inherits from spawnable object class. returns itself to the pool when the animation ends
/// </summary>
public class SpawnableAnimation : SpawnableObject
{
    [SerializeField]
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            owningPool.ReturnObject(gameObject);
        }
   
    }

    private void OnEnable()
    {
        anim.SetTrigger("Play");
    }

}