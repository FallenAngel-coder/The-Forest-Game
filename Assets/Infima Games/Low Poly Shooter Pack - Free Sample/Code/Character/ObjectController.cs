using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class ObjectController : MonoBehaviour
{
    public GameObject prefabToSpawn; // ��������� ������ ��� ������
    public Inventory inventory;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventory.weapons.Length > 1)
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
