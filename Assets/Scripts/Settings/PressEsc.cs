using UnityEngine;
using UnityEngine.UI;

public class PressEsc : MonoBehaviour
{
    public Button button; // Кнопка, яка буде викликати натискання Esc
    public PauseMenu pauseMenu;
    public void Start()
    {
        button.onClick.AddListener(PressTheEsc);
    }

    void PressTheEsc()
    {
        Debug.Log("Press Esc");
        pauseMenu.Resume();
    }
}