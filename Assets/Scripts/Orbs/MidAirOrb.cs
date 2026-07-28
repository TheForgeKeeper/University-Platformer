using JdnUtilities;
using UnityEngine;

namespace JdnUniPlat.Orbs
{
    public class MidAirOrb : Ab_Orb
    {
        private MidAirJump_DH jumpDataHolder;

        public void InjectData(MidAirJump_DH dataHolder)
        {
            jumpDataHolder = dataHolder;
        }

        public override JdnOrbs OrbType => JdnOrbs.MidAirOrb;

        public override void BreakOrb(Rigidbody rb)
        {
            rb.linearVelocity = Swizzle.XOZ(rb.linearVelocity);
            rb.AddForce(Vector3.up * jumpDataHolder.jumpForce, ForceMode.Impulse);
        }
    }
}