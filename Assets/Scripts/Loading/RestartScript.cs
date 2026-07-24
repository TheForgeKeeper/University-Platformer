using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace JdnUniPlat.Loading
{
    public class RestartScript : MonoBehaviour, IRestartScript
    {
        [SerializeField] private InputActionReference restartBinds;

        private SceneAbstaction sceneToLoad;

        public void InjectData(SceneAbstaction _sceneToLoad)
        {
            this.sceneToLoad = _sceneToLoad;
        }

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