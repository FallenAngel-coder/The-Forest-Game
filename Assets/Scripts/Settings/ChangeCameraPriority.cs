using UnityEngine;
using Cinemachine;

public class ChangeCinemachinePriority : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // ��������� �� ���� ��������� ������ Cinemachine

    // �����, ���� ���� ���������� ��� ��������� �� ������ ��� ��������� ���������
    public void DecreasePriorityOnClick()
    {
        if (virtualCamera != null)
        {
            virtualCamera.Priority -= 1; // ��������� ��������� �� 1
        }
    }

    // �����, ���� ���� ���������� ��� ��������� �� ������ ��� ��������� ���������
    public void IncreasePriorityOnClick()
    {
        if (virtualCamera != null)
        {
            virtualCamera.Priority += 1; // ��������� ��������� �� 1
        }
    }
}
