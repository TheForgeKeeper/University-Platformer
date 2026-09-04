using JdnUniPlat.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAbsBased : MonoBehaviour
{
    [SerializeField] SceneAbstraction sceneToLoad;

    public void LoadSceneAbs()
    {
        SceneManager.LoadScene((int)sceneToLoad);
    }
}
