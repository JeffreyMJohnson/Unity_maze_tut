using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighScores : MonoBehaviour
{
    int scoreCount = 5;

    // Use this for initialization
    void Start()
    {
        List<Text> textChildren = new List<Text>(GetComponentsInChildren<Text>());
        int highScoreCount = MainMenu.highScoresList.Count;
        int highScoreIndex = 0;
        for (int i = 0; i < textChildren.Count; i++)
        {
            Text t = textChildren[i];
            if (t.tag == "highScore" && highScoreIndex < highScoreCount)
            {
                HighScore hScore = MainMenu.highScoresList[highScoreIndex];
                //t.text = hScore.name + " - " +
                //    hScore.minutes + ":" + hScore.seconds;
                t.text = hScore.name + " - " + hScore.timeFormatted;
                highScoreIndex++;
            }
            else if (t.tag == "highScore")
            {
                t.text = "";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("MainMenu");
    }
}
