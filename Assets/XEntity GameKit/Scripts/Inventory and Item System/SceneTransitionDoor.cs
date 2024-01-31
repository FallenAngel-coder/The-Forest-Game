using UnityEngine;
using UnityEngine.SceneManagement;
using XEntity.InventoryItemSystem;

namespace XEntity.InteractionSystem
{
    // Цей скрипт прикріплюється до дверей або порталів, які переносять на наступну сцену при взаємодії.
    public class SceneTransitionDoor : MonoBehaviour, IInteractable
    {
        // Ім'я сцени, на яку потрібно перенести гравця.
        public string nextSceneName;

        public float interactionRadius = 2f;

        // Метод викликається при взаємодії з дверима.
        public void OnClickInteract(Interactor interactor)
        {
            // Перевірка чи ім'я наступної сцени встановлено.
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                // Переносимо гравця на наступну сцену.
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("Не вказано ім'я наступної сцени для переходу.");
            }
        }
    }
}
