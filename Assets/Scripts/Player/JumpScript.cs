using UnityEngine;
using UnityEngine.InputSystem;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private InputActionReference jumpBind;
    [SerializeField] private GroundCheck groundCheck;

    private Rigidbody Rb;
    private float gravity;

    public void InjectData(GroundCheck groundCheck)
    {
        this.groundCheck = groundCheck;
    }

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsGrounded)
        {
            Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
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
