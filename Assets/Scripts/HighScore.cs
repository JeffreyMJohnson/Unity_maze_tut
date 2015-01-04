using UnityEngine;
using System.Collections;

public class HighScore {

    public float seconds;
    public int minutes;
    public string name;

    public HighScore()
    {
        seconds = 0.0f;
        minutes = 0;
        name = "";
    }

    public HighScore(string a_name)
    {
        seconds = 0.0f;
        minutes = 0;
        name = a_name;
    }

    public HighScore(string a_name, int min, float sec)
    {
        name = a_name;
        minutes = min;
        seconds = sec;
    }

}
