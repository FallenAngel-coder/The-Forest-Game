using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> objectList1;
    public List<GameObject> objectList2;
    public List<GameObject> objectList3;
    public List<GameObject> objectList4;
    public List<GameObject> objectList5;

    public Transform spawnPoint;

    void Start()
    {
        SpawnRandomObjects();
    }

    void SpawnRandomObjects()
    {
        SpawnObjectFromList(objectList1);
        SpawnObjectFromList(objectList2);
        SpawnObjectFromList(objectList3);
        SpawnObjectFromList(objectList4);
        SpawnObjectFromList(objectList5);
    }

    void SpawnObjectFromList(List<GameObject> objList)
    {
        if (objList.Count > 0 && spawnPoint != null)
        {
            int randomIndex = Random.Range(0, objList.Count);
            GameObject objectToSpawn = objList[randomIndex];
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
            objList.RemoveAt(randomIndex); // Remove the spawned object from the list
        }
        else
        {
            Debug.LogWarning("Object list is empty or spawn point not set!");
        }
    }
}
