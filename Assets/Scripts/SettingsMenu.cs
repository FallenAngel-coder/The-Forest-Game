using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        settingsMenu.SetActive(false); // На початку меню налаштувань приховане
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true); // Показати меню налаштувань
        Cursor.lockState = CursorLockMode.None; // Розблокувати курсор
        Cursor.visible = true;
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false); // Приховати меню налаштувань
        Cursor.lockState = CursorLockMode.Locked; // Заблокувати курсор
        Cursor.visible = false;
    }

    // Додаткові методи для обробки налаштувань, які ви хочете зберегти
    public void ApplySettings()
    {
        // Збереження налаштувань, наприклад, графіки, звуку тощо
        // Додатковий код для збереження налаштувань
        CloseSettings(); // Закрити меню налаштувань після застосування змін
    }
}
