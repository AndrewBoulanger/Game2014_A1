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

    LinkedList<int> highScores;

    int score;
    int maxScores = 5;

    bool isListChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        
        highScores = new LinkedList<int>();
        
        score = PlayerPrefs.GetInt("Score");
        scoreDisplay.text = "Score: " + score;

        LoadScores();

       CheckNewScore();
        

    }

    void LoadScores()
    {
        string line = PlayerPrefs.GetString("ScoreData");



        if(line == "")
        {
            for(int i = 0; i < maxScores; i++)
                highScores.AddLast(0);
        }
        else
        {
            print(line);
            string[] scores = line.Split(',');
            foreach(string s in scores)
            {
                print(s);
                highScores.AddLast(int.Parse(s));
            }
        }

    }
    private void CheckNewScore()
    {
        LinkedListNode<int> node = highScores.First;
        while (node != null)
        {
            if (score > node.Value)
            {
                isListChanged = true;
                highScoresButton.gameObject.SetActive(true);
                AddToScoresList(node);
                break;
            }

            node = node.Next;
        }
    }

    void AddToScoresList(LinkedListNode<int> atNode)
    {
        highScores.AddBefore(atNode, score);

        while(highScores.Count > maxScores)
        { 
            highScores.RemoveLast();
        }

        string saveData = "";
        foreach(int s in highScores)
        {
            saveData += s + ",";
        }
        saveData = saveData.Substring(0, saveData.Length-1);

        PlayerPrefs.SetString("ScoreData", saveData);
    }

 

}
