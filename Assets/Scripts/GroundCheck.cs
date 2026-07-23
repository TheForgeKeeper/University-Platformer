using UnityEngine;


public class GroundCheck : MonoBehaviour
{
    [SerializeField] private int groundCount = 1;


    private void OnTriggerEnter(Collider other)
    {
        groundCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        groundCount--;
    }

    public bool IsGrounded => groundCount > 0;
}
