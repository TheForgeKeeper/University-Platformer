using UnityEngine;
using JdnUtilities;
using System.Collections.Generic;

namespace JdnUniPlat.Orbs
{
    public class OrbsDependencyInjector : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour orbStackUnv;
        [SerializeField] private MonoBehaviour cameraRelayUnv;
        [SerializeField] private MonoBehaviour playerGravityUnv;
        [SerializeField] private PlayerMovement PlayerMovement;
        [SerializeField] private DashOrb_DH dashOrbDataHolder;
        [SerializeField] private MidAirJump_DH airJumpDataHolder;

        [SerializeField] private List<Ab_Orb> orbsToInject;

        private IOrbStack orbStack;
        private ICameraRelay camRelay;
        private IPlayerGravity playerGravity;

        private void Awake()
        {
            JdnValidate.ValidateInterface(orbStackUnv,out orbStack);
            JdnValidate.ValidateInterface(cameraRelayUnv, out camRelay);
            JdnValidate.ValidateInterface(playerGravityUnv, out playerGravity);

            foreach (Ab_Orb orb in orbsToInject)
            {
                switch (orb.OrbType) 
                {
                    case JdnOrbs.MidAirOrb:
                        (orb as MidAirOrb).InjectData(orbStack, airJumpDataHolder);
                        break;

                    case JdnOrbs.DashOrb:
                        (orb as DashOrb).InjectData(orbStack ,dashOrbDataHolder,playerGravity,camRelay);
                        break;
                }

            }
        }

    }
}