using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public Maze mazePrefab;
    public Player playerPrefab;
    public Coin coinPrefab;
    public UICanvas canvasPrefab;

    private Maze mazeInstance;
    private Player playerInstance;
    private Coin coinInstance;
    private UICanvas canvasInstance;

    public static float score;


    //coroutine because of maze generation stepping 
    private void Start()
    {
        score = 0.0f;
        StartCoroutine(BeginGame());
    }

    //check input
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }


    private IEnumerator BeginGame()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);

       mazeInstance = Instantiate(mazePrefab) as Maze;
        yield return StartCoroutine(mazeInstance.Generate());

        canvasInstance = Instantiate(canvasPrefab) as UICanvas;

        playerInstance = Instantiate(playerPrefab) as Player;
        //debug 
        //playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        playerInstance.SetLocation(mazeInstance.GetCell(new IntVector2(0, 0)));
        coinInstance = Instantiate(coinPrefab) as Coin;
        //coinInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        coinInstance.SetLocation(mazeInstance.GetCell(new IntVector2(0, 3)));
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, .5f, .5f);

    }

    public void GameOver(float a_score)
    {
        score = a_score;
       Application.LoadLevel("WinScene");
    }

    //called is space bar hit
    private void RestartGame()
    {
        //this stops the maze generation if it's in the process
        StopAllCoroutines();
        score = 0.0f;
        Destroy(mazeInstance.gameObject);
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }
        if (coinInstance != null)
        {
            Destroy(coinInstance.gameObject);
        }
        if (canvasInstance != null)
        {
            Destroy(canvasInstance.gameObject);
        }
        StartCoroutine(BeginGame());
    }
}