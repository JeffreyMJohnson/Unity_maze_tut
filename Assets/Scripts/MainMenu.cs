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
        {
            highScoresList.Add(new HighScore("Jeff", 3, 1.23f));
            highScoresList.Add(new HighScore("Foo", 5, 0.0f));
            highScoresList.Add(new HighScore("Bar", 4, 3.5f));
            highScoresList.Add(new HighScore("Jeff", 1, 1.23f));
            highScoresList.Add(new HighScore("Foo", 2, 0.0f));
            highScoresList.Add(new HighScore("Bar", 4, 23.5f));
            highScoresList.Sort(new ScoreComparer());
        }
       Debug.Log("foo");
       if (highScoresList.Count == 0)
           LoadScores();

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
            FileStream fileStream = new FileStream(highScoresFilepath, FileMode.Open);
            Debug.Log("size: " + fileStream.Length);
            fileStream.Close();
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
            file.WriteLine(s.name + "," + s.minutes + "," + s.seconds);
        }
        file.Close();
        
    }

    class ScoreComparer : IComparer<HighScore>
    {
        public int Compare(HighScore x, HighScore y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    //if x is null and y is null they are equal
                    return 0;
                }
                else
                {
                    //if x is null and y is not, y is greater
                    return -1;
                }
            }
            else
            {
                //if x is not null...
                if (y == null)
                {
                    //... and y is null, x is greater
                    return 1;
                }
                else
                {
                    //... and y is not null, compare the scores
                    //if mins are not equal
                    if (x.minutes != y.minutes)
                    {
                        return (x.minutes > y.minutes) ? 1 : -1;
                    }
                    else
                    {
                        //mins are equal check secs
                        if (FloatEquals(x.seconds, y.seconds, .0001f))
                        {
                            return 0;
                        }
                        else
                        {
                            return (x.seconds > y.seconds) ? 1 : -1;
                        }
                    }
                }
            }
        }

        private bool FloatEquals(float x, float y, float delta)
        {
            return Mathf.Abs(x - y) < delta;
        }

    }
}
