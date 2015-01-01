using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinUICanvas : MonoBehaviour {
private string winningTime;

	void Start () {
        winningTime = PlayerPrefs.GetString("winningTime");
	}
    
	
	// Update is called once per frame
	void Update () {
        
        Text[] labels = GetComponentsInChildren<Text>();
        foreach (Text label in labels)
        {
            if (label.tag == "timer")
            {
                label.text = "Winning Time: " + winningTime;
            }
        }
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
