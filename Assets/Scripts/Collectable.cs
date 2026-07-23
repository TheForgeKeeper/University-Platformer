using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool isCollected = false;

    public event Action OnCollect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            OnCollect?.Invoke();
            gameObject.SetActive(false); // Optionally deactivate the collectable object
        }
    }

    public bool IsCollected => isCollected;
}
