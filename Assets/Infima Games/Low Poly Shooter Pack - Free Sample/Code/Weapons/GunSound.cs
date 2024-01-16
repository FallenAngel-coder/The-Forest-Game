using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class GunSound : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб для спавну
    public float spawnDelay = 2f; // Затримка перед видаленням
    public Transform spawnPoint; // Точка спавну (де має з'явитися префаб)

    private void Start()
    {
        // Додаємо обробник на подію вистрілу
        FindObjectOfType<Weapon>().OnFire += HandleShoot;
    }

    private void HandleShoot(bool hasFired)
    {
        if (hasFired)
        {
            // Створюємо префаб на вказаній точці спавну
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Запускаємо таймер для видалення створеного префаба через затримку
            Destroy(spawnedObject, spawnDelay);
        }
    }
}