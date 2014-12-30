using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public float rotationSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
	}

    public void SetLocation(MazeCell cell)
    {
        transform.localPosition = cell.transform.localPosition + new Vector3(0, .75f,0);
    }
}
