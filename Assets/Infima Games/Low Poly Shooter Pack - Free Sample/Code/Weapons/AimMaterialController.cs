using UnityEngine;
using Cinemachine;

public class AimMaterialController : MonoBehaviour
{
    public Camera aimCamera;
    public Renderer targetRenderer;
    public Material aimMaterial;
    public Material originalMaterial;

    void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Renderer �� ��������. ������� Renderer �� ��'���� ��� ��������� ��������� � ���������.");
            enabled = false;
            return;
        }

        originalMaterial = targetRenderer.material;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            OnAimStop();
        }
        else
        {
            OnAim();
        }
    }

    void OnAim()
    {
        // �������� aimCamera ��� �����������


        // ������ ������� ��� �����������
        targetRenderer.material = aimMaterial;
    }

    void OnAimStop()
    {
        // �������� aimCamera ��� ��������� ������������
        aimCamera.enabled = true;

        // ��������� ���������� ������� ��� ��������� ������
        targetRenderer.material = originalMaterial;
    }
}
