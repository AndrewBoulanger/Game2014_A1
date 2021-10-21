using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
