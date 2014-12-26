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

    private void Move(MazeDirection direction)
    {
        MazeCellEdge edge = currentCell.GetEdge(direction);
        if (edge is MazePassage)
        {
            SetLocation(edge.otherCell);
        }
    }

	
	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Move(currentDirection);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Move(currentDirection.GetNextClockwise());
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Move(currentDirection.GetOpposite());
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Move(currentDirection.GetNextCounterclockwise());
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Rotate(currentDirection.GetNextCounterclockwise());
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            Rotate(currentDirection.GetNextClockwise());
        }
    }
}
