using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(NextLevel());
    }

    void Update()
    {
        //Next();
    }

    IEnumerator NextLevel()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(5);
        Application.LoadLevel("MainMenu");
    }
}
