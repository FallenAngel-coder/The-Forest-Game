using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // Змінна для зберігання єдиного екземпляру SoundManager

    public Slider volumeSlider; // Слайдер для контролю гучності

    private void Awake()
    {
        // Перевірка чи екземпляр SoundManager уже існує
        if (Instance == null)
        {
            Instance = this; // Якщо ні, встановлюємо поточний екземпляр
            DontDestroyOnLoad(gameObject); // Не знищуємо цей об'єкт при переході між сценами
        }
        else
        {
            Destroy(gameObject); // Якщо SoundManager вже існує, знищуємо новий екземпляр
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Змінюємо гучність всіх звуків в грі
    }

    public void SetMinimumLowVolume()
    {
        SetVolume(0f); // Встановлюємо мінімальний рівень гучності
    }

    public void SetMinimumVolume()
    {
        SetVolume(0.2f); // Встановлюємо мінімальний рівень гучності
    }

    public void SetLowVolume()
    {
        SetVolume(0.4f); // Встановлюємо низький рівень гучності
    }

    public void SetMediumVolume()
    {
        SetVolume(0.6f); // Встановлюємо середній рівень гучності
    }

    public void SetHighVolume()
    {
        SetVolume(0.8f); // Встановлюємо високий рівень гучності
    }

    public void SetMaximumVolume()
    {
        SetVolume(1f); // Встановлюємо максимальний рівень гучності
    }
}
