///
///Author: Andrew Boulanger 101292574
///
/// File: HighScoreDisplay.cs
/// 
/// Description: loads score data to display on the high score scene
/// 
/// last Modified: Oct 24th 2021
///
/// version history: 
///     v1 reads from playerPref and changes text if not empty
/// 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// loads score data to display on the high score scene
/// </summary>
public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField]
    List<Text> displayText;

    // Start is called before the first frame update
    void Start()
    {
        LoadInScores();
    }


    private void LoadInScores()
    {
        string line = PlayerPrefs.GetString("ScoreData");
        string[] scores = line.Split(',');

        for(int i = 0; i < displayText.Count; i++)
        {
            if(line != "")
            { 
                displayText[i].text = (i +": " + scores[i] );
            }
            else
                displayText[i].text = i + ": " + 0;
        }
    }

}
