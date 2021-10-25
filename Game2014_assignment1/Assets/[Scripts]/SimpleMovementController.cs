
///
///Author: Andrew Boulanger 101292574
///
/// File: SimpleMovementController.cs
/// 
/// Description: used by any object that moves in one direction at a constant speed. (most object in this game)
///             does this through the rigidbody velocity
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 created file. sets velocity on start
///     v2 changed to set velocity when enabled too, it seems velocity was being reset to zero on disable
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  used by any object that moves in one direction at a constant speed.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class SimpleMovementController : MonoBehaviour
{

    public float speed = 2;
    public Vector3 direction = Vector3.left;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidbody.velocity = direction* speed;
    }

    private void OnEnable()
    {
        if(rigidbody != null)
            rigidbody.velocity = direction* speed;
    }
}
