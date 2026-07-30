using JdnUniPlat.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderUniPlat : MonoBehaviour
{
    [SerializeField] SceneAbstraction sceneAbstraction;

    public void LoadScene()
    {
        SceneManager.LoadScene((int)sceneAbstraction);
    }
}
