using UnityEngine;

public class CustomGravity : MonoBehaviour, IPlayerGravity
{
    [SerializeField] private float fallingGravity = 19.2f;
    [SerializeField] private float standardGravity = 9.8f;

    [SerializeField] private GroundCheck groundCheck;

    private Rigidbody Rb;
    private float gravity;
    private bool gravityDisabled = false;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.useGravity = false;
    }


    private void FixedUpdate()
    {
        if (Rb.linearVelocity.y < 0)
        {
            gravity = fallingGravity;
        }
        else
        {
            gravity = standardGravity;
        }

        if (!gravityDisabled)
        {
            gravity = 0;
        }
        Rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

    }

    public void DisableGravity()
    {
        gravityDisabled = true;
    }

    public void EnableGravity()
    {
        gravityDisabled = false;
    }
}
