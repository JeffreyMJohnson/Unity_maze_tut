using UnityEngine;

public class Player : MonoBehaviour {

    private MazeCell currentCell;
    private MazeDirection currentDirection;

    public void SetLocation(MazeCell cell)
    {
        if (currentCell != null)
        {
            currentCell.OnPlayerExited();
        }
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
        currentCell.OnPlayerEntered();
    }
 
    private void Rotate(MazeDirection direction)
    {
        transform.localRotation = direction.ToRotation();
        currentDirection = direction;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("winningTime", FindObjectOfType<UICanvas>().GetTime());
        FindObjectOfType<GameManager>().GameOver();
    }

    private void Move(MazeDirection direction)
    {
        MazeCellEdge edge = currentCell.GetEdge(direction);
        if (edge is MazePassage)
        {
            SetLocation(edge.otherCell);
        }
    }

    [Range(0f, 1f)]
    public float horizontalMoveAxisDeadZone = .25f;
    [Range(0f, 1f)]
    public float verticalMoveAxisDeadZone = .25f;
    [Range(0f, 1f)]
    public float rotateAxisDeadZone = .25f;
	
	private void Update()
    {
        float horizontalMoveAxisValue = Input.GetAxis("Horizontal");
        //Debug.Log("hor: " + horizontalMoveAxisValue);
        if(horizontalMoveAxisValue > horizontalMoveAxisDeadZone)//same as key 'D'
        {
            Move(currentDirection.GetNextClockwise());
        }
        if (horizontalMoveAxisValue < -(horizontalMoveAxisDeadZone))//same as key 'A'
        {
            Move(currentDirection.GetNextCounterclockwise());
        }

        float verticalMoveAxisValue = Input.GetAxis("Vertical");
        //Debug.Log("vert: " + verticalMoveAxisValue);
        if (verticalMoveAxisValue > verticalMoveAxisDeadZone)//same as key 'W'
        {
            Move(currentDirection);
        }
        if (verticalMoveAxisValue < -(verticalMoveAxisDeadZone))//same as key 'S'
        {
            Move(currentDirection.GetOpposite());
        }

        float rotateAxisValue = Input.GetAxis("Rotate");
        //Debug.Log("rot: " + rotateAxisValue);
        if (rotateAxisValue < -(rotateAxisDeadZone))//same as key 'Q'
        {
            Rotate(currentDirection.GetNextCounterclockwise());
        }
        if (rotateAxisValue > rotateAxisDeadZone)//same as key 'E'
        {
            Rotate(currentDirection.GetNextClockwise());
        }
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(currentDirection);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(currentDirection.GetNextClockwise());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(currentDirection.GetOpposite());
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(currentDirection.GetNextCounterclockwise());
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotate(currentDirection.GetNextCounterclockwise());
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate(currentDirection.GetNextClockwise());
        }
    }
}
