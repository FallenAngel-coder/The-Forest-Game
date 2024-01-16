using UnityEngine;

public class MoveAndDelete : MonoBehaviour
{
    public AnimationCurve moveCurve; // ����� ��� �������� �������� ������
    public float moveDuration = 3f; // ��������� ������
    public float deleteAfter = 3f; // ��� ����� ���������� ��'����

    public float elapsedTime = 0f;
    public bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        elapsedTime += Time.deltaTime;

        // ��� ��'���� �� ������
        float yPos = moveCurve.Evaluate(elapsedTime / moveDuration);
        transform.Translate(Vector3.up * yPos * Time.deltaTime);

        // ���� ��� ������ ����������, ��������� ��� �� ��������� ������ ��� ��������� ��'����
        if (elapsedTime >= moveDuration)
        {
            isMoving = false;
            Invoke("DeleteObject", deleteAfter);
        }
    }

    void DeleteObject()
    {
        // ��������� ��'���
        Destroy(gameObject);
    }
}
