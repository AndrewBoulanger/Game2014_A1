///
///Author: Andrew Boulanger 101292574
///
/// File: UFOBehaviour.cs
/// 
/// Description: state machine switching between the move and shoot AI states state. uses raycasting to check for the player
/// 
/// last Modified: Oct 24th 2021
///
/// version history: 
///     v1 
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum UFO_States
{
    Moving,
    Shooting
}

///switches between the move and shoot AI states state
public class UFOBehaviour : MonoBehaviour
{
    [SerializeField]
    UFOLaserBehaviour laserGun;
    SimpleMovementController movementController;
    Rigidbody2D rigidbody;

    [SerializeField]
    float rayDistance = 5f;

    UFO_States currentState;

    private void ChangeState(UFO_States state)
    {
        currentState = state;
        if(state == UFO_States.Moving)
        {
            laserGun.gameObject.SetActive(false);
            movementController.enabled = true;
        }
        else if(state == UFO_States.Shooting)
        {
            laserGun.gameObject.SetActive(true);
            movementController.enabled = false;
            rigidbody.velocity = Vector2.zero;
        }
    }
    
    void Start()
    {
        movementController = GetComponent<SimpleMovementController>();
        rigidbody = GetComponent<Rigidbody2D>();
        ChangeState(UFO_States.Moving);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == UFO_States.Moving)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, rayDistance,LayerMask.GetMask("Player"));
            if(hit.collider != null)
            {
                laserGun.SetTarget(hit.collider.gameObject);
                ChangeState(UFO_States.Shooting);
            }
        }
    }

    private void OnEnable()
    {
        if(laserGun != null && movementController != null)
        ChangeState(UFO_States.Moving);
    }
}
