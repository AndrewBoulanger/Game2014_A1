///
///Author: Andrew Boulanger 101292574
///
/// File: ArmCannonController.cs
/// 
/// Description: Rotates the arm cannon to aim at the player's finger
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 added file and rotation from point function
///     v2 code cleanup - removed empty update
/// 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Description: Rotates the arm cannon to aim at the player's finger

public class ArmCannonController : MonoBehaviour
{
    Vector3 direction;
    Quaternion zRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3();
        zRotation = new Quaternion();
        
    }


    //calculates rotation from the touch input passed in from the player controller
    public void SetRotationFromPoint(Vector3 point)
    {
        direction = (point - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        zRotation = Quaternion.AngleAxis(angle, Vector3.forward);
  
        transform.rotation = zRotation;
    }
}