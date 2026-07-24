using UnityEngine;
using UnityEngine.InputSystem;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fallingGravity = 19.2f;
    [SerializeField] private float standardGravity = 9.8f;

    [SerializeField] private InputActionReference jumpBind;
    [SerializeField] private GroundCheck groundCheck;

    private Rigidbody Rb;
    private float gravity;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.useGravity = false;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsGrounded)
        {
            Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if(Rb.linearVelocity.y < 0)
        {
            gravity = fallingGravity;
        }
        else
        {
            gravity = standardGravity;
        }
        Rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    private void OnEnable()
    {
        jumpBind.action.performed += Jump;
    }

    private void OnDisable()
    {
        jumpBind.action.performed -= Jump;
    }
}
