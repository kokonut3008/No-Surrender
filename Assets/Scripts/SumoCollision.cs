using UnityEngine;

public class SumoCollision : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Rigidbody otherRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Get object with which player/bot collides
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bot"))
        {
            if (collision.gameObject.tag == "Bot" || collision.gameObject.tag == "Player")
            {   
                otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

                Transform myTransform = GetComponent<Transform>();
                Transform otherTransform = collision.gameObject.GetComponent<Transform>();

                // Get reflection direction after collision
                Vector3 reflectionDirectionA = Vector3.Reflect(myTransform.forward, otherTransform.position - myTransform.position).normalized;
                Vector3 reflectionDirectionB = Vector3.Reflect(otherTransform.forward, myTransform.position - otherTransform.position).normalized;
                
                // If one of object doesnt move
                if (reflectionDirectionA == Vector3.zero)
                {
                    reflectionDirectionA = -reflectionDirectionB;
                }

                if (reflectionDirectionB == Vector3.zero)
                {
                    reflectionDirectionB = -reflectionDirectionA;
                }

                // Calculate force w.r.t. masses of objects
                float myForce = 4 * (otherRigidbody.mass / myRigidbody.mass) * otherRigidbody.mass;
                float otherForce = 4 * (myRigidbody.mass / otherRigidbody.mass) * myRigidbody.mass;

                // Apply force in reflection direction
                myRigidbody.AddForce(myForce * reflectionDirectionA, ForceMode.Impulse);
                otherRigidbody.AddForce(otherForce * reflectionDirectionB, ForceMode.Impulse);
            }
        }
    }
}
