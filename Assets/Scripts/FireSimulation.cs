using UnityEngine;

public class FireSimulation : MonoBehaviour
{
    public float minIntensity = 1f;
    public float maxIntensity = 5f;
    public float changeInterval = 0.5f;

    private Light fireLight;
    private float currentIntensity;

    void Start()
    {
        fireLight = GetComponent<Light>();
        currentIntensity = fireLight.intensity;

        // Запускаємо метод для зміни інтенсивності через заданий інтервал
        InvokeRepeating("ChangeIntensity", 0f, changeInterval);
    }

    void ChangeIntensity()
    {
        // Генеруємо випадкову інтенсивність між min та max
        currentIntensity = Random.Range(minIntensity, maxIntensity);
        // Застосовуємо нову інтенсивність до світла
        fireLight.intensity = currentIntensity;
    }
}
