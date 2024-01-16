using UnityEngine;
using XEntity.InventoryItemSystem;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public GameObject prefabToAdd; // ��������� �� ������, ���� �� ������ ������ �� �����
    public string parentPrefabName = "ParentPrefabName"; // ��'� ������������ �������

    public void OnClickInteract(Interactor interactor)
    {
        // ��������� �������� ��'��� � �����
        Destroy(gameObject);

        // ��������� ����������� ������ �� ������
        GameObject parentPrefab = GameObject.Find(parentPrefabName);
        if (parentPrefab != null)
        {
            // �������� �� �������� �������, ���� �� � ������
            if (prefabToAdd != null)
            {
                // ��������� ����� ��������� ������� �� ���� � ������ ���� ������� ��'����� ������������ �������
                Instantiate(prefabToAdd, parentPrefab.transform);
            }
            else
            {
                Debug.LogError("Prefab to add is not assigned!");
            }
        }
        else
        {
            Debug.LogError("Parent prefab not found!");
        }
    }
}