using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MoveToSceneZero()
    {
        SceneManager.LoadScene(0);
    }

    public void MoveToSceneOne()
    {
        SceneManager.LoadScene(1);
    }

    public void MoveToSceneTwo()
    {
        SceneManager.LoadScene(2);
    }
}