using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Loading
{
    public class ReadyScreenScript : MonoBehaviour
    {
        [SerializeField] private InputActionReference onReadyBinds;
        [SerializeField] private InputActionReference playerMap;
        [SerializeField] private InputActionReference UIMap;
        [SerializeField] private Canvas isNotReadyCanvas;

        public UnityEvent OnReady;


        private void Start()
        {
            playerMap.action.actionMap.Disable();
            UIMap.action.actionMap.Disable();
            onReadyBinds.action.Enable();
            isNotReadyCanvas.enabled = true;

        }

        private void StartRunOnReady(InputAction.CallbackContext context)
        {
            playerMap.action.actionMap.Enable();
            UIMap.action.actionMap.Enable();
            onReadyBinds.action.Disable();
            isNotReadyCanvas.enabled = false;
            OnReady?.Invoke();
        }

        private void OnEnable()
        {
            onReadyBinds.action.performed += StartRunOnReady;
        }

        private void OnDisable()
        {
            onReadyBinds.action.performed -= StartRunOnReady;

        }
    }
}