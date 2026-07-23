using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class tokenTracker : MonoBehaviour
{
    [SerializeField] private List<Collectable> tokens; // List of all collectable objects in the scene

    public UnityEvent onAllTokensCollected;

    private HashSet<Collectable> activeTokens = new HashSet<Collectable>();

    private void Start()
    {
        foreach (Collectable token in tokens)
        {
            AddToken(token);
        }
    }

    private void HandleCollectableCollected(Collectable token)
    {
        token.OnCollect -= HandleCollectableCollected;
        activeTokens.Remove(token);

        if(activeTokens.Count == 0)
        {
            onAllTokensCollected?.Invoke();
        }
    }

    private void AddToken(Collectable token)
    {
        token.OnCollect += HandleCollectableCollected;
        activeTokens.Add(token);
    }
}
