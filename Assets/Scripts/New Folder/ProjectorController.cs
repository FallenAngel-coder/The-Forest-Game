using UnityEngine;

public class ProjectorController : MonoBehaviour
{
    private Light ���������; // ����� ��� ���������� ��������� �� ��������� "�����"

    void Start()
    {
        // �������� ��������� �� ��������� "�����" ��'����
        ��������� = GetComponent<Light>();
    }

    void Update()
    {
        // ����������, �� ��������� ������ "F" �� ��������
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ������� ���� ���������� �� �����������
            ���������.enabled = !���������.enabled;
        }
    }
}