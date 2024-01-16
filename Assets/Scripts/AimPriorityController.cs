using UnityEngine;
using Cinemachine;

public class AimPriorityController : MonoBehaviour
{
    public CinemachineVirtualCamera aimCamera;
    private int initialPriority;
    private const int priorityIncrease = 5;

    void Start()
    {
        // �������� ���������� �������� ������ �������
        initialPriority = aimCamera.m_Priority;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // �������� �� ���������� ����� ������ ����
        {
            // �������� �������� ��������� ������ �������
            aimCamera.m_Priority = initialPriority + priorityIncrease;
        }
        else
        {
            // ��������� �������� �� ����������� �������� ��� ��������� ������
            aimCamera.m_Priority = initialPriority;
        }
    }
}
