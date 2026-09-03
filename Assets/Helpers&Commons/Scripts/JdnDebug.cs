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
}
