using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        settingsMenu.SetActive(false); // �� ������� ���� ����������� ���������
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true); // �������� ���� �����������
        Cursor.lockState = CursorLockMode.None; // ������������ ������
        Cursor.visible = true;
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false); // ��������� ���� �����������
        Cursor.lockState = CursorLockMode.Locked; // ����������� ������
        Cursor.visible = false;
    }

    // �������� ������ ��� ������� �����������, �� �� ������ ��������
    public void ApplySettings()
    {
        // ���������� �����������, ���������, �������, ����� ����
        // ���������� ��� ��� ���������� �����������
        CloseSettings(); // ������� ���� ����������� ���� ������������ ���
    }
}
