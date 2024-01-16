using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // ����� ��� ��������� ������� ���������� SoundManager

    public Slider volumeSlider; // ������� ��� �������� �������

    private void Awake()
    {
        // �������� �� ��������� SoundManager ��� ����
        if (Instance == null)
        {
            Instance = this; // ���� �, ������������ �������� ���������
            DontDestroyOnLoad(gameObject); // �� ������� ��� ��'��� ��� ������� �� �������
        }
        else
        {
            Destroy(gameObject); // ���� SoundManager ��� ����, ������� ����� ���������
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // ������� ������� ��� ����� � ��
    }

    public void SetMinimumLowVolume()
    {
        SetVolume(0f); // ������������ ��������� ����� �������
    }

    public void SetMinimumVolume()
    {
        SetVolume(0.2f); // ������������ ��������� ����� �������
    }

    public void SetLowVolume()
    {
        SetVolume(0.4f); // ������������ ������� ����� �������
    }

    public void SetMediumVolume()
    {
        SetVolume(0.6f); // ������������ ������� ����� �������
    }

    public void SetHighVolume()
    {
        SetVolume(0.8f); // ������������ ������� ����� �������
    }

    public void SetMaximumVolume()
    {
        SetVolume(1f); // ������������ ������������ ����� �������
    }
}
