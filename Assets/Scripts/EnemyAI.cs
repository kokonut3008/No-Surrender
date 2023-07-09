using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public SushiSpawner sushiSpawner; // Reference to the SushiSpawner script
    public List<GameObject> allObjects;
    public List<GameObject> PlayerBotsArr; // Array for bots and player objects

    public GameObject nearestObject;
    float distance;
    float nearestDistance;
    public float moveSpeed = 5f;

    void Start()
    {
        // Access the spawnedSushiArray from SushiSpawner script
        allObjects = new List<GameObject>();
    }

    void Update()
    {
        // Merge allObjects list with spawnedSushiArray
        allObjects.Clear();
        allObjects.AddRange(sushiSpawner.spawnedSushiArray);
        allObjects.AddRange(PlayerBotsArr);

        nearestDistance = 1000f;

        // Find nearest bot/player/sushi
        for (int i = 0; i < allObjects.Count; i++)
        {
            if (allObjects[i] == null)
            {
                allObjects.RemoveAt(i);
                continue;
            }

            // Count distance to the nearest object
            distance = Vector3.Distance(transform.position, allObjects[i].transform.position);
            if (distance < nearestDistance)
            {
                nearestObject = allObjects[i];
                nearestDistance = distance;
            }
        }

        if (nearestObject != null)
        {
            // Rotate towards the nearest object
            float rotationSpeed = 10f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nearestObject.transform.position - transform.position), Time.deltaTime * rotationSpeed);


            // Move forward in the direction the bot is facing
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
