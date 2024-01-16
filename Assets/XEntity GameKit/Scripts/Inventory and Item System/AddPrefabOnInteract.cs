using UnityEngine;

namespace XEntity.InventoryItemSystem
{
    // Цей скрипт додає певний префаб до вказаного об'єкту за тегом при взаємодії і потім видаляє себе
    public class AddPrefabAndDestroyAfterUse : MonoBehaviour, IInteractable
    {
        public string tagToAddPrefabTo; // Тег для пошуку об'єкту, до якого додається префаб
        public GameObject prefabToAdd; // Префаб, який буде доданий до об'єкту

        private void CheckPrefabCountAndAdd()
        {
            GameObject objectToAddPrefabTo = GameObject.FindWithTag(tagToAddPrefabTo); // Знаходження об'єкту за тегом
            if (objectToAddPrefabTo != null)
            {
                AddPrefabToObject(objectToAddPrefabTo); // Виклик функції з об'єктом, знайденим за тегом
            }
            else
            {
                Debug.LogWarning("Об'єкт не знайдено за вказаним тегом!");
            }
        }

        public void OnClickInteract(Interactor interactor)
        {
            CheckPrefabCountAndAdd();
            Destroy(gameObject); // Видаляємо об'єкт із цим скриптом після використання
        }

        private void AddPrefabToObject(GameObject objectToAddPrefabTo)
        {
            // Перевірка наявності префаба для додавання
            if (prefabToAdd != null)
            {
                // Створення нового екземпляру префабу з нульовими координатами та поворотом
                GameObject newObject = Instantiate(prefabToAdd, Vector3.zero, Quaternion.identity);

                // Встановлення батьківського об'єкту для нового екземпляру
                newObject.transform.parent = objectToAddPrefabTo.transform;

                // Скидання позиції та повороту нового об'єкту на нуль
                newObject.transform.localPosition = Vector3.zero;
                newObject.transform.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.LogWarning("Не вказано префаб для додавання!");
            }
        }
    }
}
