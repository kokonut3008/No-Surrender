using UnityEngine;

public class Sushi : MonoBehaviour
{
    public float growthAmount = 0.05f;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bot"))
        {
            EatSushi(other.gameObject);
        }
    }

    private void EatSushi(GameObject player)
    {
        // Increase mass and size of the player
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            playerRigidbody.mass += growthAmount;
        }

        // Increase size of the player
        Vector3 newScale = player.transform.localScale + new Vector3(growthAmount, growthAmount, growthAmount);
        player.transform.localScale = newScale;

        Destroy(gameObject);
    }
}
