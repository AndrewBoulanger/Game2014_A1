using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //if (anim.isPlaying == false)
        //{
        //    owningPool.ReturnObject(gameObject);
        //}
    }

    private void OnEnable()
    {
        anim.SetTrigger("Play");
    }

}