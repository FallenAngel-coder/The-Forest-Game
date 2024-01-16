using UnityEngine;

public class ProjectorController : MonoBehaviour
{
    private Light прожектор; // Змінна для збереження посилання на компонент "Світло"

    void Start()
    {
        // Отримуємо посилання на компонент "Світло" об'єкта
        прожектор = GetComponent<Light>();
    }

    void Update()
    {
        // Перевіряємо, чи натиснута клавіша "F" на клавіатурі
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Змінюємо стан прожектора на протилежний
            прожектор.enabled = !прожектор.enabled;
        }
    }
}