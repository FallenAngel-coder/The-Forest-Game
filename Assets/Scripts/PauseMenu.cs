using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGameOnEsc = false;
    public static bool PauseGameOnInv = false;
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
            if (PauseGameOnEsc)
            {
                Resume();
                PauseGameOnEsc = false;
                pauseMenu.SetActive(false);
            }
            else if (!PauseGameOnInv) 
            {
                Pause();
                PauseGameOnEsc = true;
                pauseMenu.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (PauseGameOnInv)
            {
                Resume();
                PauseGameOnInv = false;
                pauseMenu.SetActive(false);
            }
            else if(!PauseGameOnEsc)
            {
                Pause();
                PauseGameOnInv = true;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    

        Cursor.lockState = CursorLockMode.Locked; // При відновленні гри блокуємо курсор
        Cursor.visible = false;
    }


    public void Pause()
    {
        Time.timeScale = 0f;


        Cursor.lockState = CursorLockMode.None; // При паузі розблоковуємо курсор
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}