using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class Recoil : MonoBehaviour
{
    [SerializeField]
    private string objectTag; // Тег, за яким будемо шукати об'єкт для віддачі

    [SerializeField]
    private float maxRecoilAngle = 30f;

    [SerializeField]
    private float recoilSpeed = 5f;

    [SerializeField]
    private AnimationCurve recoilCurve; // Крива для управління ефектом віддачі

    private Transform objectToRecoil; // Об'єкт для застосування віддачі
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
            objectToRecoil = objectsWithTag[0].transform; // Беремо перший знайдений об'єкт з відповідним тегом
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

            float recoilAmount = maxRecoilAngle * recoilCurve.Evaluate(recoilTimer); // Використовуємо криву для отримання значення віддачі

            Quaternion recoilRotation = Quaternion.Euler(-recoilAmount, 0f, 0f);
            objectToRecoil.localRotation *= recoilRotation;

            if (recoilTimer >= 1f)
            {
                isRecoiling = false;
            }
        }
    }
}