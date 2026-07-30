using JdnUniPlat.Orbs;
using JdnUtilities;
using System;
using UnityEngine;

public class Player_RH : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MonoBehaviour camRelayUnv;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GroundCheck groundCheck;

    [Header("Dependent")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private OrbStack orbStack;
    [SerializeField] private JumpScript jumpScript;
    [SerializeField] private CustomGravity gravity;

    private OrbStackUI GetOrbStackUI() => Canvas.GetComponent<OrbStackUI>();

    private void Awake()
    {
        JdnValidate.ValidateInterface(camRelayUnv, out ICameraRelay camRelay);
        playerMovement.InjectData(camRelay);  
        orbStack.InjectData(GetOrbStackUI());
        jumpScript.InjectData(groundCheck);
        gravity.InjectData(groundCheck);
    }
}
