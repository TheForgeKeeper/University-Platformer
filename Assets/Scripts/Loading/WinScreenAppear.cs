using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WinScreenAppear : MonoBehaviour
{
    [SerializeField] List<InputActionReference> mapsToDisable = new List<InputActionReference>();
    [SerializeField] Canvas winScreenCanvas;

    public UnityEvent OnWin;
    public void EnableWinScreen()
    {
        foreach (InputActionReference Action in mapsToDisable) Action.action.actionMap.Disable();
        winScreenCanvas.enabled = true;
        OnWin?.Invoke();
    }
}
