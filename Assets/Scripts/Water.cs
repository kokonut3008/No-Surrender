using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bot"))
        {
            KillObject(other.gameObject);
        }
    }

    private void KillObject(GameObject obj)
    {
        Destroy(obj);
    }
}
