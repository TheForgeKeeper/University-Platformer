using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Loading
{
    public class ReadyScreenScript : MonoBehaviour, IReadyScreenScript
    {
        [SerializeField] private InputActionReference onReadyBinds;
        [SerializeField] private InputActionReference playerMap;
        private Canvas isNotReadyScreenCanvas;

        private void Start()
        {
            onReadyBinds.action.Enable();
            playerMap.action.actionMap.Disable();
            isNotReadyScreenCanvas.enabled = true;
        }

        public void InjectData(Canvas isReadyScreenCanvas)
        {
            this.isNotReadyScreenCanvas = isReadyScreenCanvas;
        }

        private void StartRunOnReady(InputAction.CallbackContext context)
        {
            playerMap.action.actionMap.Enable();
            onReadyBinds.action.Disable();
            isNotReadyScreenCanvas.enabled = false;
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