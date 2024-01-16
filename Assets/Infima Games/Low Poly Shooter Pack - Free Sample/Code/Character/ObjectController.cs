using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class ObjectController : MonoBehaviour
{
    public GameObject prefabToSpawn; // ��������� ������ ��� ������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnPrefab(); // ����� ������ ��'���� ��� ��������� Q
            Destroy(gameObject); // ��������� ��������� ��'����, �� ����� ��� ������
        }
    }

    void SpawnPrefab()
    {
        // �������� �������� ������� ��� ������
        if (prefabToSpawn != null)
        {
            // ��������� ������ ��'���� � ������������� �������
            GameObject newObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            // �������� 䳿 � ����� ��'����� (���� �������)
        }
        else
        {
            Debug.LogError("Prefab ��� ������ �� �������!");
        }
    }
}
