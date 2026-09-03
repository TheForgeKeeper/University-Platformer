using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions inputActions = null;
    
    public InputSystem_Actions GetInputActions()
    {
        if(inputActions == null)
        {
            inputActions = new InputSystem_Actions();
        }

        return inputActions;
    }
}
