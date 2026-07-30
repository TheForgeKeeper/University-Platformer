using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace JdnUniPlat.Loading
{
    public class RestartScript : MonoBehaviour
    {
        [SerializeField] private InputActionReference restartBinds;
        [SerializeField] private SceneAbstraction sceneToLoad;

        private void RestartRun(InputAction.CallbackContext context)
        {
            SceneManager.LoadScene((int)sceneToLoad);
        }

        private void OnEnable()
        {
            restartBinds.action.performed += RestartRun;
        }

        private void OnDisable()
        {
            restartBinds.action.performed -= RestartRun;
        }
    }
}