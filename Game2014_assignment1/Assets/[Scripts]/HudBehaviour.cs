using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum HudFunctions
{
    AddToScore,
    ChangeHealth,
    nothing
}

public delegate void HudDelegate(HudFunctions function, int val);
public class HudBehaviour : MonoBehaviour
{
    int score = 0;
    int lives = 3;
    int maxLives = 3;

    [SerializeField]
    SpriteRenderer[] crosses;

    [SerializeField]
    Text scoreText;

    Timer time;

    public HudDelegate hudDelegate;
    // Start is called before the first frame update
    void Start()
    {
        time = new Timer();

        hudDelegate = UpdateHudInfo;
    }

    // Update is called once per frame
    void Update()
    {
        if(time.GetTime() > 1)
        {
            time.Reset();
            AddToScore(1);
        }
    }

    public void UpdateHudInfo(HudFunctions function, int val)
    {
        if(function == HudFunctions.AddToScore)
        {
            AddToScore(val);
        }
        if(function == HudFunctions.ChangeHealth)
        {
            UpdateLives(val);
        }
    }


    private void UpdateLives(int changeInHealth)
    {
        lives += changeInHealth;
        if(lives > maxLives)
            lives = maxLives;

        for(int i = 0; i < maxLives; i++)
        {
            if(lives > i)
                crosses[i].gameObject.SetActive(false);
            else
                crosses[i].gameObject.SetActive(true);
        }
        if(lives <= 0)
        { 
            SceneManager.LoadScene(SceneList.GameOverScreen);
            PlayerPrefs.SetInt("Score", score);
        }
    }

    private void AddToScore(int pointsToAdd)
    {
        score +=  pointsToAdd;
        scoreText.text = "score: "+ score;
    }
}

