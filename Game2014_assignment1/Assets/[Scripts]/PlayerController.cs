using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                laser.gameObject.SetActive(true);
            }
            else
            {
                laser.gameObject.SetActive(false);
            }
        }
        else
        {
            laser.gameObject.SetActive(false);
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

    private void setLerpValues(int lastRow, float moveDistance)
    {
        isLerping = true;
        this.lastRow = lastRow;
        lerpStartTime = Time.time;
        lerpDistance = moveDistance;
    }

}
