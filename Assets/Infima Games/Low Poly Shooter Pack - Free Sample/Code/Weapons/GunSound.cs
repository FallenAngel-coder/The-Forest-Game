using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class GunSound : MonoBehaviour
{
    public GameObject prefabToSpawn; // ������ ��� ������
    public float spawnDelay = 2f; // �������� ����� ����������
    public Transform spawnPoint; // ����� ������ (�� �� �'������� ������)

    private void Start()
    {
        // ������ �������� �� ���� �������
        FindObjectOfType<Weapon>().OnFire += HandleShoot;
    }

    private void HandleShoot(bool hasFired)
    {
        if (hasFired)
        {
            // ��������� ������ �� ������� ����� ������
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            // ��������� ������ ��� ��������� ���������� ������� ����� ��������
            Destroy(spawnedObject, spawnDelay);
        }
    }
}