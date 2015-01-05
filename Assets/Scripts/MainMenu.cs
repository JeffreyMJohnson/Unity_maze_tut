using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class MainMenu : MonoBehaviour
{

    public static List<HighScore> highScoresList = new List<HighScore>();
    public string highScoresFilepath = @".\Assets\highscores.txt";

    void Start()
    {

        if (highScoresList.Count == 0)
            LoadScores();

    }

    public static void AddScore(HighScore a_score)
    {
        highScoresList.Add(a_score);
        highScoresList.Sort(new HighScoreComparer());
        if (highScoresList.Count > 5)
        {
            highScoresList.RemoveRange(5, highScoresList.Count - 5);
        }
    }

    public static bool IsHighScore(float a_score)
    {
        if (a_score < highScoresList[highScoresList.Count - 1].time)
        {
            return true;
        }
        return false;
    }

    public void StartGameOnClick()
    {
        Application.LoadLevel("GamePlay");

    }

    public void QuitGameOnClick()
    {
        SaveScores();
        Application.Quit();
        Debug.Log("Quit game clicked.");
    }

    public void HighScoresOnClick()
    {
        Application.LoadLevel("HighScores");
    }

    public void DirectionsOnClick()
    {
        Application.LoadLevel("Directions");
    }

    void LoadScores()
    {

        if (File.Exists(highScoresFilepath))
        {
            //FileStream fileStream = new FileStream(highScoresFilepath, FileMode.Open);
            StreamReader file = new StreamReader(highScoresFilepath);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                Debug.Log("line: " + line);
                string[] data = line.Split(',');
                HighScore score = new HighScore(data[0], float.Parse(data[1]));
                highScoresList.Add(score);
            }

            file.Close();
        }
        else
        {
            Debug.Log("nope");
        }

    }

    void SaveScores()
    {
        if (File.Exists(highScoresFilepath))
            File.Delete(highScoresFilepath);
        StreamWriter file = new StreamWriter(highScoresFilepath);
        int maxCount = highScoresList.Count > 5 ? 5 : highScoresList.Count;
        for (int i = 0; i < maxCount; i++)
        {
            HighScore s = highScoresList[i];
            file.WriteLine(s.name + "," + s.time);
        }
        file.Close();

    }

    
}
