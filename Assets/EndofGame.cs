using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofGame : MonoBehaviour
{
    //PlayerMovement Cursor;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerMovement.Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        //Debug.Log("Cursor unlocked and visible");
    }

public void RestartScene(string scenename)
    {
         SceneManager.LoadScene(scenename);
    }
}
