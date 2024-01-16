using UnityEngine;

namespace XEntity.InventoryItemSystem
{
    // ��� ������ ���� ������ ������ �� ��������� ��'���� �� ����� ��� �����䳿 � ���� ������� ����
    public class AddPrefabAndDestroyAfterUse : MonoBehaviour, IInteractable
    {
        public string tagToAddPrefabTo; // ��� ��� ������ ��'����, �� ����� �������� ������
        public GameObject prefabToAdd; // ������, ���� ���� ������� �� ��'����

        private void CheckPrefabCountAndAdd()
        {
            GameObject objectToAddPrefabTo = GameObject.FindWithTag(tagToAddPrefabTo); // ����������� ��'���� �� �����
            if (objectToAddPrefabTo != null)
            {
                AddPrefabToObject(objectToAddPrefabTo); // ������ ������� � ��'�����, ��������� �� �����
            }
            else
            {
                Debug.LogWarning("��'��� �� �������� �� �������� �����!");
            }
        }

        public void OnClickInteract(Interactor interactor)
        {
            CheckPrefabCountAndAdd();
            Destroy(gameObject); // ��������� ��'��� �� ��� �������� ���� ������������
        }

        private void AddPrefabToObject(GameObject objectToAddPrefabTo)
        {
            // �������� �������� ������� ��� ���������
            if (prefabToAdd != null)
            {
                // ��������� ������ ���������� ������� � ��������� ������������ �� ���������
                GameObject newObject = Instantiate(prefabToAdd, Vector3.zero, Quaternion.identity);

                // ������������ ������������ ��'���� ��� ������ ����������
                newObject.transform.parent = objectToAddPrefabTo.transform;

                // �������� ������� �� �������� ������ ��'���� �� ����
                newObject.transform.localPosition = Vector3.zero;
                newObject.transform.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.LogWarning("�� ������� ������ ��� ���������!");
            }
        }
    }
}
