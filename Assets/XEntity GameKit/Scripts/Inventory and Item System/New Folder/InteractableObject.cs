using UnityEngine;
using XEntity.InventoryItemSystem;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public GameObject prefabToAdd; // Посилання на префаб, який ви хочете додати на сцену
    public string parentPrefabName = "ParentPrefabName"; // Ім'я батьківського префаба

    public void OnClickInteract(Interactor interactor)
    {
        // Видаляємо поточний об'єкт з сцени
        Destroy(gameObject);

        // Знаходимо батьківський префаб за іменем
        GameObject parentPrefab = GameObject.Find(parentPrefabName);
        if (parentPrefab != null)
        {
            // Перевірка на наявність префабу, який не є клоном
            if (prefabToAdd != null)
            {
                // Створюємо новий екземпляр префабу на сцені і робимо його дочірнім об'єктом батьківського префаба
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