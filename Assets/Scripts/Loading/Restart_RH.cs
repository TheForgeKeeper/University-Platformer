using Assets.Scripts.Loading;
using JdnUtilities;
using UnityEngine;

namespace JdnUniPlat.Loading
{
    public class Restart_RH : MonoBehaviour
    {
        //Dependencies
        [SerializeField] Canvas readyScreen;
        [SerializeField] SceneAbstaction sceneToLoad;

        //Dependent
        [SerializeField] MonoBehaviour restartScriptUnv;
        [SerializeField] MonoBehaviour readyScreenScriptUnv;

        private IRestartScript restartScript;
        private IReadyScreenScript readyScreenScript;

        private void Awake()
        {
            JdnValidate.ValidateInterface(restartScriptUnv, out restartScript);
            JdnValidate.ValidateInterface(readyScreenScriptUnv, out readyScreenScript);

            restartScript.InjectData(sceneToLoad);
            readyScreenScript.InjectData(readyScreen);
        }
    }
}