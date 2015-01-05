using UnityEngine;
using System.Collections.Generic;

public class HighScore
{

    //public float seconds;
    //public int minutes;
    public string name;
    public float time;
    public string timeFormatted;

    public HighScore()
    {
        //seconds = 0.0f;
        //minutes = 0;
        name = "";
        time = 0.0f;
        timeFormatted = "00:00:00";
    }

    //public HighScore(string a_name)
    //{
    //    //seconds = 0.0f;
    //    //minutes = 0;
    //    name = a_name;
    //    time = 0.0f;
    //    timeFormatted = "00:00:00";
    //}

    //public HighScore(string a_name, int min, float sec)
    //{
    //    name = a_name;
    //    //minutes = min;
    //    //seconds = sec;
    //}

    public HighScore(string a_name, float a_time)
    {
        //float t = a_time;
        //if (t > 60)
        //{
        //    minutes = (int)(t / 60);
        //    t -= minutes * 60;
        //}
        //seconds = t;
        name = a_name;
        time = a_time;
        timeFormatted = GetFormattedHighScore();
    }

    public string GetFormattedHighScore()
    {
        float t = time;
        int min = 0;
        int sec = 0;
        int mill = 0;
        if (t > 60)
        {
            min = (int)(t / 60);
            t -= min * 60;
        }
        sec = (int)t;
        mill = (int)((t - sec)* 100);
        string r = "";
        if (min == 0)
        {
            r = "00";
        }
        else
        {
            r = min + "";
        }
        r += ":";
        if (sec == 0)
        {
            r += "00";
        }
        else
        {
            r += sec + "";
        }
        r += ":";
        if (mill == 0)
        {
            r += "00";
        }
        else
        {
            r += mill;
        }
        return r;
    }

    //public static bool operator > (HighScore lhs, HighScore rhs)
    //{
    //    if (rhs == null || lhs == null)
    //        return false;
    //    //if minutes are greater
    //    if (lhs.minutes > rhs.minutes)
    //        return true;
    //    else if (lhs.minutes < rhs.minutes)
    //        return false;
    //    //minutes equal
    //    if (lhs.seconds > rhs.seconds)
    //        return true;
    //    else
    //        return false;
    //}

    
}

class HighScoreComparer : IComparer<HighScore>
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
                //if (x.minutes != y.minutes)
                //{
                //    return (x.minutes > y.minutes) ? 1 : -1;
                //}
                //else
                //{
                //    //mins are equal check secs
                //    if (FloatEquals(x.seconds, y.seconds, .0001f))
                //    {
                //        return 0;
                //    }
                //    else
                //    {
                //        return (x.seconds > y.seconds) ? 1 : -1;
                //    }
                //}
                if (x.time != y.time)
                {
                    return (x.time > y.time) ? 1 : -1;
                }
                else return 0;
            }
        }
    }

    private bool FloatEquals(float x, float y, float delta)
    {
        return Mathf.Abs(x - y) < delta;
    }
}