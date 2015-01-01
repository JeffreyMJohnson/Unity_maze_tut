using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void StartGameOnClick()
    {
        Application.LoadLevel("GamePlay");
    }

    public void QuitGameOnClick()
    {
        Application.Quit();
        Debug.Log("Quit game clicked.");
    }

    public void HighScoresOnClick()
    {
        Debug.Log("High scores clicked.");
    }

    public void DirectionsOnClick()
    {
        Debug.Log("Directions clicked.");
    }
}
