using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public static Volume Instance; // ����� ��� ��������� ������� ���������� Volume

    public Slider volumeSlider; // ������� ��� �������� �������

    private void Awake()
    {
        // �������� �� ��������� Volume ��� ����
        if (Instance == null)
        {
            Instance = this; // ���� �, ������������ �������� ���������
            DontDestroyOnLoad(gameObject); // �� ������� ��� ��'��� ��� ������� �� �������
        }
        else
        {
            Destroy(gameObject); // ���� Volume ��� ����, ������� ����� ���������
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // ������� ������� ��� ����� � ��
    }
}