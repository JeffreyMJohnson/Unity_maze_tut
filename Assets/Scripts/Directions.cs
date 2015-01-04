using UnityEngine;
using System.Collections;

public class Directions : MonoBehaviour {
	void Update () {
	if (Input.GetKeyDown(KeyCode.Escape))
    {
        Application.LoadLevel("MainMenu");
    }
	}
}
