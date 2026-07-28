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

        public void InjectData(DashOrb_DH dataHolder, IPlayerGravity playerGravity , ICameraRelay cameraRelay)
        {
            this.dashOrb_DH = dataHolder;
            this.playerGravity = playerGravity;
            this.cameraRelay = cameraRelay;
        }

        public override JdnOrbs OrbType => JdnOrbs.DashOrb;

        public override void BreakOrb(Rigidbody rb)
        {
            // Cancel Initial forces
            playerGravity.DisableGravity();
            rb.linearVelocity = Swizzle.XOZ(rb.linearVelocity);

            // Calculate fireDirection and dash
            Vector3 fireDirection = Swizzle.XOY(cameraRelay.CamAdjustInputsXZ(Vector2.up));
            rb.AddForce(fireDirection * dashOrb_DH.dashForce, ForceMode.Impulse);

            // Enable Gravity
            JdnCoroutines.CallAfterTime(playerGravity.EnableGravity,dashOrb_DH.dashDuration);
        }

        
    }
}