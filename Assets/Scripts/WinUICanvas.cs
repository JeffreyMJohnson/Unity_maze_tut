using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinUICanvas : MonoBehaviour {
private string winningTime;
public RectTransform enterHighScorePanel;

	void Start () {
       // winningTime = PlayerPrefs.GetString("winningTime");
        if (MainMenu.highScoresList.Count < 5 || GameManager.score < MainMenu.highScoresList[MainMenu.highScoresList.Count - 1].time)
            enterHighScorePanel.gameObject.SetActive(true);
        else
        {
            enterHighScorePanel.gameObject.SetActive(false);
        }
	}
    
	
	// Update is called once per frame
	void Update () {
        Text[] labels = GetComponentsInChildren<Text>();
        foreach (Text label in labels)
        {
            if (label.tag == "timer")
            {
                label.text = "Winning Time: " + new HighScore("", GameManager.score).timeFormatted;
            }
        }

	}

    public void SetHighScore(string text)
    {
        InputField textBox = enterHighScorePanel.GetComponentInChildren<InputField>();
        HighScore score = new HighScore(textBox.text, GameManager.score);
        MainMenu.AddScore(score);
        //Debug.Log("name: " + score.name);
        //Debug.Log("score: " + score.timeFormatted);
        enterHighScorePanel.gameObject.SetActive(false);

    }

    public void NewMazeButtonClick()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("GamePlay");
    }

    public void QuitToMainMenuOnClick()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("MainMenu");
    }
}
