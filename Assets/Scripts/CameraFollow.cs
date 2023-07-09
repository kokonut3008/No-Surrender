using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Transform playerTr;
    private float minDistance = 3f;
    private float maxDistance = 10f;
    private float movementSpeed = 5f;
    private float distanceMultiplier = 5f;


    private Vector3 initialOffset;
    private float targetDistance;

    private void Start()
    {
        initialOffset = transform.position - playerTr.position;
        targetDistance = initialOffset.magnitude;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = playerTr.position + initialOffset.normalized * targetDistance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        float currentDistance = Vector3.Distance(transform.position, playerTr.position);

        // Move camera after player if he is too far or too close to the camera
        if (currentDistance < minDistance)
        {
            targetDistance += 0.1f;
        }
        else if (currentDistance > maxDistance)
        {
            targetDistance -= 0.1f;
        }

        minDistance = player.GetComponent<Rigidbody>().mass * distanceMultiplier;

    }

    void Update()
    {
        // Check if the player reference is set
        if (player != null)
        {

            Vector3 direction = player.transform.position - transform.position;

            // Rotate the camera to look at the player
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
