using UnityEngine;
using UnityEngine.UI;

public class PressEsc : MonoBehaviour
{
    public Button button; // Кнопка, яка буде викликати натискання Esc

    public void Start()
    {
        button.onClick.AddListener(PressTheEsc);
    }

    void PressTheEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc була натиснута");
        }
    }
}