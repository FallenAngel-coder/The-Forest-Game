using UnityEngine;

public class CubemapTransition : MonoBehaviour
{
    public Transform lightTransform; // ��������� �� ��������� �����
    public float transitionDuration = 3.0f; // ��������� ��������
    public float rotationSpeed = 3f; // �������� ���������

    public Material material; // ��������� �� �������, ���� ������ �������� _CubemapTransition

    private bool isTransitioning = false;
    private float transitionTimer = 2f;
    private float startValue = 0f;
    private float targetValue = 0f;

    void Update()
    {
        //// ��������� ��'���� �� ���� ������ �� X
        //float rotationAmount = rotationSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.right, rotationAmount);

        //// �������� �������� ����� �� X
        //float lightRotationX = lightTransform.rotation.eulerAngles.x;

        //// ����������, �� ����� ����������� � ��������� �������
        //if (lightRotationX >= -5f && lightRotationX <= 175f)
        //{
        //    targetValue = 1f; // ���� ����� � �������, ������������ ������� �������� 1
        //}
        //else
        //{
        //    targetValue = 0f; // ���� ����� �� � �������, ������������ ������� �������� 0
        //}

        //// ������� �������
        //if (targetValue != material.GetFloat("_CubemapTransition"))
        //{
        //    if (!isTransitioning)
        //    {
        //        isTransitioning = true;
        //        startValue = material.GetFloat("_CubemapTransition");
        //        transitionTimer = 0f;
        //    }

        //    transitionTimer += Time.deltaTime;

        //    float t = Mathf.Clamp01(transitionTimer / transitionDuration);
        //    t = Mathf.SmoothStep(startValue, targetValue, t);

        //    material.SetFloat("_CubemapTransition", t);

        //    if (transitionTimer >= transitionDuration)
        //    {
        //        isTransitioning = false;
        //    }
        //}
    }
}   