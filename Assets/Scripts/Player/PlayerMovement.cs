using JdnUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 3f;
    [SerializeField] private float deceleration = 7f;
    
    [SerializeField]private InputActionReference MovementAction;
    [SerializeField]private InputActionReference ToggleCursor;
    
    private ICameraRelay camRelay;
    private Vector2 camAdjustedInput;
    private Rigidbody Rb;

    #endregion

    private Vector2 GetCurrentVelocity() => Swizzle.XZ(Rb.linearVelocity);
    private Vector2 GetTargetVelocity() => camAdjustedInput * maxSpeed;
    private bool isDecelerating() => GetTargetVelocity().magnitude < GetCurrentVelocity().magnitude;

    public void InjectData(ICameraRelay cameraRelay)
    {
        this.camRelay = cameraRelay;
    }

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        DisableCursor();
    }

    private void FixedUpdate()
    {
        Vector2 inputVec = MovementAction.action.ReadValue<Vector2>();
        camAdjustedInput = camRelay.CamAdjustInputsXZ(inputVec);

        float finalAcceleration = isDecelerating() ? deceleration : acceleration;
        Vector3 finalForce  = Swizzle.XOY(GetTargetVelocity() - GetCurrentVelocity()) * finalAcceleration;

        Rb.AddForce(finalForce,ForceMode.Force);

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
