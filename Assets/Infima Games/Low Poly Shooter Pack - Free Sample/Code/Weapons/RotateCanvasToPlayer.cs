using UnityEngine;

public class RotateCanvasToPlayer : MonoBehaviour
{
    public string playerTag = "Player"; // ��� ������
    private Transform player; // ��������� �� ��� ������

    void Start()
    {
        // ��������� ������ �� �����
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("������� �� ���������! �������� ��� ������.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // �������� ������, ���� ����� � Canvas �� ������
            Vector3 direction = player.position - transform.position;

            // ��������� Canvas � �������� ������ � ��������� ���������
            transform.rotation = Quaternion.LookRotation(-direction);
        }
        else
        {
            Debug.LogWarning("������� �� ��������! ������� ��������� �� ������ �� �������.");
        }
    }
}
