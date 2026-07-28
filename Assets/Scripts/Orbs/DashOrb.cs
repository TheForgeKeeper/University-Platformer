using JdnUtilities;
using Unity.VisualScripting;
using UnityEngine;

namespace JdnUniPlat.Orbs
{
    public class DashOrb : Ab_Orb
    {
        private DashOrb_DH dashOrb_DH;
        private IPlayerGravity playerGravity;
        private ICameraRelay cameraRelay;

        protected override IOrbStack OrbStack { get; set; }

        public void InjectData(IOrbStack OrbStack, DashOrb_DH dataHolder, IPlayerGravity playerGravity , ICameraRelay cameraRelay)
        {
            this.dashOrb_DH = dataHolder;
            this.playerGravity = playerGravity;
            this.cameraRelay = cameraRelay;
            this.OrbStack = OrbStack;
        }

        public override JdnOrbs OrbType => JdnOrbs.DashOrb;

        public override void BreakOrb(Rigidbody rb)
        {
            Debug.Log("dashOrbBroke");
            // Cancel Initial forces
            playerGravity.DisableGravity();
            rb.linearVelocity = Swizzle.XOZ(rb.linearVelocity);

            // Calculate fireDirection and dash
            Vector3 fireDirection = Swizzle.XOY(cameraRelay.CamAdjustInputsXZ(Vector2.up));
            rb.AddForce(fireDirection * dashOrb_DH.dashForce, ForceMode.Impulse);

            // Enable Gravity
            playerGravity.EnableGravityAfterTime(dashOrb_DH.dashDuration);
        }

        private void wrapper()
        {
            Debug.Log("re-enabled graviy");
            playerGravity.EnableGravity();
        }
    }
}