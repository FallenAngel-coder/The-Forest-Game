using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private LineRenderer лінія; // Змінна для збереження посилання на компонент "LineRenderer"

    void Start()
    {
        // Отримуємо посилання на компонент "LineRenderer" об'єкта
        лінія = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Перевіряємо, чи натиснута клавіша "F" на клавіатурі
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Змінюємо стан компонента "LineRenderer" на протилежний
            лінія.enabled = !лінія.enabled;
        }
    }
}
