using TMPro;
using Unity.Cinemachine;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

public class JdnPlayerTriggerCollision : MonoBehaviour
{
    public UnityEvent OnPlayerEnterTrigger;
    [TagField][SerializeField] private string playerTag = "player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            OnPlayerEnterTrigger?.Invoke();
        }
    }
}
