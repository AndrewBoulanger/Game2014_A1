using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    Text scoreDisplay;
    [SerializeField]
    Button highScoresButton;

    string saveDataPath;
    // Start is called before the first frame update
    void Start()
    {
        saveDataPath = Application.dataPath + Path.DirectorySeparatorChar + "saveData";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
