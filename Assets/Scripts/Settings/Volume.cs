using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public static Volume Instance; // «м≥нна дл€ збер≥ганн€ Їдиного екземпл€ру Volume

    public Slider volumeSlider; // —лайдер дл€ контролю гучност≥

    private void Awake()
    {
        // ѕерев≥рка чи екземпл€р Volume уже ≥снуЇ
        if (Instance == null)
        {
            Instance = this; // якщо н≥, встановлюЇмо поточний екземпл€р
            DontDestroyOnLoad(gameObject); // Ќе знищуЇмо цей об'Їкт при переход≥ м≥ж сценами
        }
        else
        {
            Destroy(gameObject); // якщо Volume вже ≥снуЇ, знищуЇмо новий екземпл€р
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // «м≥нюЇмо гучн≥сть вс≥х звук≥в в гр≥
    }
}