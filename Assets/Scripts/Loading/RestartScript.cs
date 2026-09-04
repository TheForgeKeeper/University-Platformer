using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace JdnUniPlat.Loading
{
    public class RestartScript : MonoBehaviour
    {
        [SerializeField] private InputActionReference restartBinds;
        [SerializeField] private SceneAbstraction sceneToLoad;

        private void RestartRunHandler(InputAction.CallbackContext context)
        {
            RestartRun();
        }

        public void RestartRun()
        {
            SceneManager.LoadScene((int)sceneToLoad);
        }

        private void OnEnable()
        {
            restartBinds.action.performed += RestartRunHandler;
        }

        private void OnDisable()
        {
            restartBinds.action.performed -= RestartRunHandler;
        }
    }
}