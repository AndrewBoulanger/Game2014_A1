
///
///Author: Andrew Boulanger 101292574
///
/// File: Timer.cs
/// 
/// Description: used to track time passed. I had a lot of time based stuff, so it became easier to make a class
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 returned current time - start time
///     v2 created the isTimer done function to reset itself when done
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// used to track time passed.
/// </summary>
public class Timer 
{

    public float startTime = 0;

    public Timer()
    {
        Reset();
    }

    public float GetTime()
    {
        return Time.time - startTime;
    }
    public void Reset()
    {
        startTime = Time.time;
    }

    public bool IsTimerDone(float endTime, bool reset = true)
    {
        bool timerDone = false;
        if(GetTime() > endTime)
        { 
            timerDone = true;
            if(reset)
                Reset();
        }
        return timerDone;
    }
}
