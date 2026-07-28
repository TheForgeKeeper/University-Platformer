using JdnUniPlat.Orbs;
using JdnUtilities;
using UnityEngine;

public class Player_RH : MonoBehaviour
{
    [SerializeField] private MonoBehaviour camRelayUnv;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private OrbStack orbStack;

    private OrbStackUI GetOrbStackUI() => Canvas.GetComponent<OrbStackUI>();

    private void Awake()
    {
        JdnValidate.ValidateInterface(camRelayUnv, out ICameraRelay camRelay);
        playerMovement.InjectData(camRelay);  
        orbStack.InjectData(GetOrbStackUI()); 
    }
}
