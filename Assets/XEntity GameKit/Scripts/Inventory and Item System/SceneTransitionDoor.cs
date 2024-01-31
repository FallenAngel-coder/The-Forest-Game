using UnityEngine;
using UnityEngine.SceneManagement;
using XEntity.InventoryItemSystem;

namespace XEntity.InteractionSystem
{
    // ��� ������ ������������� �� ������ ��� �������, �� ���������� �� �������� ����� ��� �����䳿.
    public class SceneTransitionDoor : MonoBehaviour, IInteractable
    {
        // ��'� �����, �� ��� ������� ��������� ������.
        public string nextSceneName;

        public float interactionRadius = 2f;

        // ����� ����������� ��� �����䳿 � �������.
        public void OnClickInteract(Interactor interactor)
        {
            // �������� �� ��'� �������� ����� �����������.
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                // ���������� ������ �� �������� �����.
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("�� ������� ��'� �������� ����� ��� ��������.");
            }
        }
    }
}
