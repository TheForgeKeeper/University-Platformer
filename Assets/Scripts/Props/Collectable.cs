using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool isCollected = false;
    public event Action<Collectable> OnCollect;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collectable triggered by: {other.name}");
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            OnCollect?.Invoke(this);
            gameObject.SetActive(false); // Optionally deactivate the collectable object
        }
    }

    public bool IsCollected => isCollected;
}
