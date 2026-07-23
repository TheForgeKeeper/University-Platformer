using JdnUtilities;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float acceleration = 3f;
    [SerializeField] float deceleration = 7f;
    //[SerializeField] float jumpForce = 5f;
    
    [SerializeField] InputActionReference MovementAction;
    [SerializeField] InputActionReference ToggleCursor;
    //[SerializeField] InputActionReference JumpAction;
    [SerializeField] Transform cam_transform;

    private Vector2 camAdjustedInput;
    private Rigidbody Rb;

    #endregion

  
    private Vector2 GetCurrentVelocity() => Swizzle.XZ(Rb.linearVelocity);
    private Vector2 GetTargetVelocity() => camAdjustedInput * maxSpeed;
    private bool isDecelerating() => GetTargetVelocity().magnitude < GetCurrentVelocity().magnitude;


    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        DisableCursor();
    }

    private void FixedUpdate()
    {
        Vector2 inputVec = MovementAction.action.ReadValue<Vector2>();
        camAdjustedInput = CamAdjustInputs(inputVec);

        float finalAcceleration = isDecelerating() ? deceleration : acceleration;
        Vector3 finalForce  = Swizzle.XOY(GetTargetVelocity() - GetCurrentVelocity()) * finalAcceleration;

        Rb.AddForce(finalForce,ForceMode.Force);

    }

    private Vector2 CamAdjustInputs(Vector2 rawInput)
    {
        float camRotationY = cam_transform.eulerAngles.y * Mathf.Deg2Rad;
        Vector2 adjustedInput;
        adjustedInput.x = rawInput.x * Mathf.Cos(camRotationY) + rawInput.y * Mathf.Sin(camRotationY);
        adjustedInput.y = -rawInput.x * Mathf.Sin(camRotationY) + rawInput.y * Mathf.Cos(camRotationY);
        return adjustedInput;
    }

    private void OnEnable()
    {
        ToggleCursor.action.performed += EnableCursor;
        ToggleCursor.action.canceled += DisableCursor;
    }

    private void OnDisable()
    {
        ToggleCursor.action.performed -= EnableCursor;
        ToggleCursor.action.canceled -= DisableCursor;
    }

    private void EnableCursor(InputAction.CallbackContext context = new InputAction.CallbackContext())
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DisableCursor(InputAction.CallbackContext context = new InputAction.CallbackContext())
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
