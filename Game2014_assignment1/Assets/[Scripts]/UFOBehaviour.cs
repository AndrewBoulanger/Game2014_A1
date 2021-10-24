using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum UFO_States
{
    Moving,
    Shooting
}
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
}
