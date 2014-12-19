﻿using UnityEngine;

public class GameManager : MonoBehaviour {
    public Maze mazePrefab;

    private Maze mazeInstance;

	// Use this for initialization
	void Start () {
        BeginGame();
	}


	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Space))
    {
        RestartGame();
    }
	}

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    } 
    
    private void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(mazeInstance.Generate());
    }
}
