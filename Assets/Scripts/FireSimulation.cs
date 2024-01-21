using UnityEngine;

public class FireSimulation : MonoBehaviour
{
    public float minIntensity = 1f;
    public float maxIntensity = 5f;
    public float changeInterval = 0.5f;

    private Light fireLight;
    private float currentIntensity;

    void Start()
    {
        fireLight = GetComponent<Light>();
        currentIntensity = fireLight.intensity;

        // ��������� ����� ��� ���� ������������ ����� ������� ��������
        InvokeRepeating("ChangeIntensity", 0f, changeInterval);
    }

    void ChangeIntensity()
    {
        // �������� ��������� ������������ �� min �� max
        currentIntensity = Random.Range(minIntensity, maxIntensity);
        // ����������� ���� ������������ �� �����
        fireLight.intensity = currentIntensity;
    }
}
