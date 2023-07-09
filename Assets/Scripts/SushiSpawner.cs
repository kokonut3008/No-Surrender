using System.Collections;
using UnityEngine;

public class SushiSpawner : MonoBehaviour
{
    public GameObject sushiPrefab;
    public Transform floorPlane;
    private int maxSushiCount = 150;
    private float spawnInterval = 1f;

    private int sushiCount;
    public GameObject[] spawnedSushiArray;

    private void Start()
    {
        spawnedSushiArray = new GameObject[maxSushiCount];
        StartCoroutine(SpawnSushi());
    }

    private IEnumerator SpawnSushi()
    {
        while (sushiCount < maxSushiCount)
        {
            // Generater sushi at random place on floor every second
            Vector3 randomPosition = GenerateRandomPositionOnFloor();
            GameObject spawnedSushi = Instantiate(sushiPrefab, randomPosition, Quaternion.identity);
            spawnedSushiArray[sushiCount] = spawnedSushi;
            sushiCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GenerateRandomPositionOnFloor()
    {
        // Generate random location on floor
        Vector3 floorSize = floorPlane.localScale;
        float randomX = Random.Range(-15, 15);
        float randomZ = Random.Range(-15, 15);
        Vector3 randomPosition = new Vector3(randomX, 1f, randomZ);
        return floorPlane.position + randomPosition;
    }
}
