using JdnUniPlat.Orbs;
using UnityEngine;

public class Player_RH : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private OrbStack orbStack;

    private Transform GetCameraTransform() => mainCamera.transform;
    private OrbStackUI GetOrbStackUI() => Canvas.GetComponent<OrbStackUI>();

    private void Awake()
    {
        playerMovement.InjectData(GetCameraTransform());
        orbStack.InjectData(GetOrbStackUI());
    }
}
