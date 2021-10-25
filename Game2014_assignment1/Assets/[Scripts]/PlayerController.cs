///
///Author: Andrew Boulanger 101292574
///
/// File: PlayerController.cs
/// 
/// Description: controls how player input affects the player. movement and laser firing.  lerps for movement
/// 
/// last Modified: Oct 21th 2021
///
/// version history: 
///     v1 added the ability to move up and down with swiping
///     v2 added the ability to shoot (well passing touch info to the laser) by holding the right side of the screen
///     v3 removed a bug with the static prefabs in the instruction screens. they'll work even if they dont have an arm cannon attached
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controls how player input affects the player. movement and laser firing. lerps for movement
/// </summary>
public class PlayerController : MonoBehaviour
{
    //row parameters
    const float rowHeight = 2.6f;
    const float dividerX = -6.0f;
    public Vector3[] rows; 
    int currentRow = 0;
    const int numRows = 3;

    float touchVerticalDeadZone = 50f;

    ArmCannonController arm;
    PlayerLaserController laser;

    
    //lerp parameters
    int lastRow;
    bool isLerping = false;
    float lerpStartTime;
    float lerpDistance;
    float MoveSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rows = new Vector3[numRows]
        {
            transform.position,
            new Vector3(transform.position.x, transform.position.y + rowHeight, 0.0f),
            new Vector3(transform.position.x, transform.position.y + (2*rowHeight), 0.0f)
        };
        arm = GetComponentInChildren<ArmCannonController>();
        laser = GetComponentInChildren<PlayerLaserController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector3 worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            //left side of the screen
            if(worldTouch.x < dividerX)
            { 
                if(touch.phase == TouchPhase.Moved && Mathf.Abs(touch.deltaPosition.y) > touchVerticalDeadZone && !isLerping)
                { 
                    TryToMove(touch.deltaPosition.y);
                }
            }

            //right side of the screen
            if(worldTouch.x > dividerX)
            {
                arm.SetRotationFromPoint(worldTouch);
                SetLaserActive(true);
            }
            else
            {
                SetLaserActive(false);
            }
        }
        else
        {
            SetLaserActive(false);
        }

        if(isLerping)
        {
            float distanceCovered = (Time.time - lerpStartTime) * MoveSpeed;
            float fractionOfJourney = distanceCovered/ lerpDistance;

            transform.position = Vector3.Lerp(rows[lastRow], rows[currentRow], fractionOfJourney);

            if(fractionOfJourney >= 0.99f)
                isLerping = false;
        }
    }

    //if moving to a row within bounds set the lerp values to move to that spot.
    private void TryToMove(float VerticalDirection)
    {
        if(VerticalDirection > 0 && currentRow < numRows-1 )
        {
            currentRow++;
            setLerpValues(currentRow-1, Vector3.Distance(rows[currentRow-1], rows[currentRow]));
        }

        else if(VerticalDirection < 0 && currentRow > 0)
        {
            currentRow--;
            setLerpValues(currentRow+1, Vector3.Distance(rows[currentRow+1], rows[currentRow]));
        }

    }

    private void SetLaserActive(bool isActive)
    {
        if(laser != null)
            laser.gameObject.SetActive(isActive);
    }

    //sets the starting pos and the distance of the lerp
    private void setLerpValues(int lastRow, float moveDistance)
    {
        isLerping = true;
        this.lastRow = lastRow;
        lerpStartTime = Time.time;
        lerpDistance = moveDistance;
    }

}
