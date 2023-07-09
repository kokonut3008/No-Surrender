using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCollided : MonoBehaviour
{
    public GameObject lastCollidedObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Water"))
        {
            // Saving lastCollidedObject which neither "Water" nor "Floor" for score counting           
            if(!collision.gameObject.CompareTag("Floor"))
            {
                lastCollidedObject = collision.gameObject;
            }
        }
        else
        {
            // The bot collided with the "Water"
            Die();
        }
    }

    private void Die()
    {
        if (lastCollidedObject != null)
        {
            // Access the last collided object and perform Scale and Mass changes to the object that pushed this object to the water
            Vector3 oldScale = lastCollidedObject.GetComponent<Transform>().localScale;
            float newMass = lastCollidedObject.GetComponent<Rigidbody>().mass + 0.2f * GetComponent<Rigidbody>().mass;
            float massIncrease = newMass / lastCollidedObject.GetComponent<Rigidbody>().mass;
            lastCollidedObject.GetComponent<Transform>().localScale = new Vector3(oldScale.x * massIncrease, oldScale.y * massIncrease, oldScale.z * massIncrease);
            lastCollidedObject.GetComponent<Rigidbody>().mass = newMass;
        }
        // Delete object that touched water
        Destroy(gameObject);

    }
}
