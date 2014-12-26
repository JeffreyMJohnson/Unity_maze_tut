using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;
    public Player playerPrefab;

	private Maze mazeInstance;
    private Player playerInstance;

    //coroutine because of maze generation stepping 
	private void Start () {
		StartCoroutine(BeginGame());
	}
	
    //check input
	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}


	private IEnumerator BeginGame () {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());
        playerInstance = Instantiate(playerPrefab) as Player;
        playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, .5f, .5f);
	}

    //called is space bar hit
	private void RestartGame () {
        //this stops the maze generation if it's in the process
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
		StartCoroutine(BeginGame());
	}
}