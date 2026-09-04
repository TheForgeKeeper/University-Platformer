using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private InputActionReference pauseBind;
    [SerializeField] private InputActionReference mapToDisable;

    private bool isPaused = false;

    public void PauseGame() 
    { 
        Time.timeScale = 0f;
        isPaused = true;
        pauseCanvas.enabled = true;
        
        mapToDisable.action.actionMap.Disable();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseCanvas.enabled = false;

        mapToDisable.action.actionMap.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void PauseHandler(InputAction.CallbackContext context)
    {
        if(isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
        pauseBind.action.Enable();
        pauseBind.action.performed += PauseHandler;

    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        pauseBind.action.Disable();
        pauseBind.action.performed -= PauseHandler;
    }
}

