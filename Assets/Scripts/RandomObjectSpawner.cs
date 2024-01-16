using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Масив префабів для спавну
    public int numberOfObjectsToSpawn = 5;
    public Terrain terrain;
    public Transform spawnCenter;
    public float spawnRadius = 10f;

    void Start()
    {
        SpawnRandomObjects();
    }

    void SpawnRandomObjects()
    {
        if (terrain == null || prefabsToSpawn == null || prefabsToSpawn.Length == 0 || spawnCenter == null)
        {
            Debug.LogWarning("Terrain, prefab array, or spawn center not set.");
            return;
        }

        float terrainHeight = terrain.SampleHeight(spawnCenter.position);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            int randomPrefabIndex = Random.Range(0, prefabsToSpawn.Length); // Вибираємо випадковий префаб
            Vector3 randomPosition = GetRandomPositionInCircle(spawnCenter.position, spawnRadius, terrainHeight);
            Instantiate(prefabsToSpawn[randomPrefabIndex], randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionInCircle(Vector3 center, float radius, float height)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float randomRadius = Random.Range(0f, radius);

        float x = center.x + randomRadius * Mathf.Cos(angle);
        float z = center.z + randomRadius * Mathf.Sin(angle);

        float y = terrain.SampleHeight(new Vector3(x, 0, z));
        return new Vector3(x, y, z);
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnCenter != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnCenter.position, spawnRadius);
        }
    }
}
