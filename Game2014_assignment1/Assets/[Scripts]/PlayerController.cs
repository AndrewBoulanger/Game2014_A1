using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float rowHeight = 2.6f;
    const float dividerX = -6.0f;

    [SerializeField]
    public Vector3[] rows; 
    int currentRow = 0;
    const int numRows = 3;

    float inputDelay = 0.25f;
    float touchVerticalDeadZone = 50f;

    ArmCannonController arm;
    PlayerLaserController laser;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer();
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
                if(touch.phase == TouchPhase.Moved && Mathf.Abs(touch.deltaPosition.y) > touchVerticalDeadZone && timer.GetTime() > inputDelay)
                { 
                    TryToMove(touch.deltaPosition.y);
                    timer.Reset();
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
    }

    private void TryToMove(float VerticalDirection)
    {
        if(VerticalDirection > 0 && currentRow < numRows-1 )
        {
            currentRow++;
            transform.position = rows[currentRow];
        }

        else if(VerticalDirection < 0 && currentRow > 0)
        {
            currentRow--;
            transform.position = rows[currentRow];
        }

    }

}
