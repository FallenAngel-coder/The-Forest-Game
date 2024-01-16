using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class ObjectController : MonoBehaviour
{
    public GameObject prefabToSpawn; // Передайте префаб для спавну

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnPrefab(); // Спавн нового об'єкта при натисканні Q
            Destroy(gameObject); // Видалення поточного об'єкта, на якому цей скрипт
        }
    }

    void SpawnPrefab()
    {
        // Перевірка наявності префабу для спавну
        if (prefabToSpawn != null)
        {
            // Створення нового об'єкта з використанням префабу
            GameObject newObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            // Додаткові дії з новим об'єктом (якщо потрібно)
        }
        else
        {
            Debug.LogError("Prefab для спавну не заданий!");
        }
    }
}
