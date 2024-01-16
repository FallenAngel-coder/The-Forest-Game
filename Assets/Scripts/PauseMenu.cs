using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame;
    public GameObject pauseMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Початково блокуємо курсор
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
                pauseMenu.SetActive(false);
            }
            else
            {
                Pause();
                pauseMenu.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (PauseGame)
            {
                Resume();
                pauseMenu.SetActive(false);
            }
            else
            {
                Pause();
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseGame = false;
        Cursor.lockState = CursorLockMode.Locked; // При відновленні гри блокуємо курсор
        Cursor.visible = false;
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        PauseGame = true;
        Cursor.lockState = CursorLockMode.None; // При паузі розблоковуємо курсор
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}