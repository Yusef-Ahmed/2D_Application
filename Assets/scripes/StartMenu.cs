using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // for the start button
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex*0+1); 
    }
}
