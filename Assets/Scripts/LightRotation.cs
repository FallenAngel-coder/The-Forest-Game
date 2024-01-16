using UnityEngine;

public class LightRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Швидкість обертання у градусах за секунду
    public float minRotationAngle = -179f; // Мінімальний кут повороту
    public float maxRotationAngle = -1f;   // Максимальний кут повороту

    private Light directionalLight;

    private void Start()
    {
        // Отримуємо компонент Directional Light при запуску
        directionalLight = GetComponent<Light>();
    }

    private void Update()
    {
        // Розраховуємо кут повороту на осі X в градусах
        float rotationAngle = Time.time * rotationSpeed;

        // Повертаємо Directional Light на заданий кут по осі X
        directionalLight.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);

        // Перевіряємо, чи кут знаходиться в інтервалі для вимкнення світла
        if (rotationAngle >= minRotationAngle && rotationAngle <= maxRotationAngle)
        {
            // Вимикаємо світло
            directionalLight.enabled = false;
        }
        else
        {
            // Увімкнемо світло, якщо кут не в інтервалі
            directionalLight.enabled = true;
        }
    }
}