using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow; // ��'���, �� ���� �������
    public float followSpeed = 5f; // �������� "���������"

    void Update()
    {
        // ����������, �� ������������ ��'��� ��� ����������
        if (objectToFollow != null)
        {
            // ��������� ���� ������� ��� ��������� ��'����, ��� �� ������� �� ��'�����, ���� �� ������
            Vector3 newPos = Vector3.Lerp(transform.position, objectToFollow.position, followSpeed * Time.deltaTime);
            transform.position = newPos; // ������������ ���� �������
        }
    }
}
