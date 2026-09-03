using UnityEngine;
using UnityEngine.Events;

public class TestEventTrigger : MonoBehaviour
{
    [SerializeField] bool call;
    public UnityEvent onCall;

    private void OnValidate()
    {
        if(call)
        {
            onCall.Invoke();
            call = false;
        }
    }
}
