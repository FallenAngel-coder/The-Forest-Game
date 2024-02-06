using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGameOnEsc = false;
    public static bool PauseGameOnInv = false;
    public GameObject pauseMenu;
    public InfimaGames.LowPolyShooterPack.Character character;
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
            else if (!PauseGameOnInv && !PauseGameOnEsc) 
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
                Cursor.visible = false;
            }
            else if(!PauseGameOnInv && !PauseGameOnEsc)
            {
                Pause();
                PauseGameOnInv = true;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked; // При відновленні гри блокуємо курсор
        Cursor.visible = false;
        character.cursorLocked = true;
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; // При паузі розблоковуємо курсор
        Cursor.visible = true;
        character.cursorLocked = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}