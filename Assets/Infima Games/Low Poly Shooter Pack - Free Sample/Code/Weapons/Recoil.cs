using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class Recoil : MonoBehaviour
{
    [SerializeField]
    private string objectTag; // ���, �� ���� ������ ������ ��'��� ��� ������

    [SerializeField]
    private float maxRecoilAngle = 30f;

    [SerializeField]
    private float recoilSpeed = 5f;

    [SerializeField]
    private AnimationCurve recoilCurve; // ����� ��� ��������� ������� ������

    private Transform objectToRecoil; // ��'��� ��� ������������ ������
    private Quaternion originalRotation;
    private bool isRecoiling = false;
    private float recoilTimer = 0f;

    private void Start()
    {
       
    }

    private void OnEnable()
    {
        FindObjectOfType<Weapon>().OnFire += HandleRecoil;
    }

    private void HandleRecoil(bool hasFired)
    {
        if (hasFired)
        {
            FindObjectToRecoil();
            isRecoiling = true;
            recoilTimer = 0f;
        }
    }

    private void FindObjectToRecoil()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(objectTag);
        if (objectsWithTag.Length > 0)
        {
            objectToRecoil = objectsWithTag[0].transform; // ������ ������ ��������� ��'��� � ��������� �����
        }
        else
        {
            Debug.LogWarning("No object found with the specified tag: " + objectTag);
        }
    }

    private void Update()
    {
        if (isRecoiling)
        {
            recoilTimer += Time.deltaTime * recoilSpeed;

            float recoilAmount = maxRecoilAngle * recoilCurve.Evaluate(recoilTimer); // ������������� ����� ��� ��������� �������� ������

            Quaternion recoilRotation = Quaternion.Euler(-recoilAmount, 0f, 0f);
            objectToRecoil.localRotation *= recoilRotation;

            if (recoilTimer >= 1f)
            {
                isRecoiling = false;
            }
        }
    }
}