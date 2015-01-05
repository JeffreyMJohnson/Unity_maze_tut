using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICanvas : MonoBehaviour
{

    Text text;

    string timeString;
    float totalTime = 0.0f;
    int min, sec, milli;
    HighScore score = new HighScore();
    void Start()
    {
        text = GetComponentInChildren<Text>();
        min = 0;
        sec = 0;
        milli = 0;

    }

    //public string GetTime()
    //{
    //    return text.text;
    //}

    public float GetTime()
    {
        return totalTime;
    }

    //public HighScore GetHighScore()
    //{
    //    return new HighScore(totalTime);
    //}

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime > 60)
        {
            min++;
            totalTime -= 60;
        }
        sec = (int)totalTime;
        milli = (int)((totalTime - sec) * 10);

        text.text = min + ":" + sec + ":" + milli;
    }

    void Reset()
    {
        totalTime = 0.0f;
    }

    void Hide()
    {
        text.gameObject.SetActive(false);
    }

    void Show()
    {
        text.gameObject.SetActive(true);
        Reset();
    }

    private int GetMinutes(float timeInSeconds)
    {
        return (int)(timeInSeconds / 60.0f);
    }


}
