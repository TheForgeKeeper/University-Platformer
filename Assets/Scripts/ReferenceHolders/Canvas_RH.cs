using Assets.Scripts.Loading;
using JdnUniPlat.Orbs;
using UnityEngine;

public class Canvas_RH : MonoBehaviour
{
    [SerializeField] private OrbStack orbStack;
    [SerializeField] private ReadyScreenScript readyScreenScript;


    public ReadyScreenScript GetReadyScreenScript()
    {
        return readyScreenScript;
    }

    public IOrbStack GetOrbStack()
    {
        return orbStack;   
    }
}
