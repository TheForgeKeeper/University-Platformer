using UnityEngine;

public class JdnDebug : MonoBehaviour
{
    [SerializeField] private bool PrintCollidedColliders = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(PrintCollidedColliders)
        {
            Debug.Log($"Collided with: {collision.collider.name}");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (PrintCollidedColliders)
        {
            Debug.Log($"Triggered by : {collider.name}");
        }
    }


}
