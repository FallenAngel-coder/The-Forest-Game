using UnityEngine;

public class LightRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // �������� ��������� � �������� �� �������
    public float minRotationAngle = -179f; // ̳�������� ��� ��������
    public float maxRotationAngle = -1f;   // ������������ ��� ��������

    private Light directionalLight;

    private void Start()
    {
        // �������� ��������� Directional Light ��� �������
        directionalLight = GetComponent<Light>();
    }

    private void Update()
    {
        // ����������� ��� �������� �� �� X � ��������
        float rotationAngle = Time.time * rotationSpeed;

        // ��������� Directional Light �� ������� ��� �� �� X
        directionalLight.transform.rotation = Quaternion.Euler(rotationAngle, 0f, 0f);

        // ����������, �� ��� ����������� � �������� ��� ��������� �����
        if (rotationAngle >= minRotationAngle && rotationAngle <= maxRotationAngle)
        {
            // �������� �����
            directionalLight.enabled = false;
        }
        else
        {
            // �������� �����, ���� ��� �� � ��������
            directionalLight.enabled = true;
        }
    }
}