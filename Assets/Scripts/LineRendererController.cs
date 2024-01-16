using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private LineRenderer ���; // ����� ��� ���������� ��������� �� ��������� "LineRenderer"

    void Start()
    {
        // �������� ��������� �� ��������� "LineRenderer" ��'����
        ��� = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // ����������, �� ��������� ������ "F" �� ��������
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ������� ���� ���������� "LineRenderer" �� �����������
            ���.enabled = !���.enabled;
        }
    }
}
