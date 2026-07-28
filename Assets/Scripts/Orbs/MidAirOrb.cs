using JdnUtilities;
using UnityEngine;

namespace JdnUniPlat.Orbs
{
    public class MidAirOrb : Ab_Orb
    {
        private MidAirJump_DH jumpDataHolder;
        protected override IOrbStack OrbStack { get; set; }

        public void InjectData(IOrbStack orbStack, MidAirJump_DH dataHolder)
        {
            jumpDataHolder = dataHolder;
            OrbStack = orbStack;
        }

        public override JdnOrbs OrbType => JdnOrbs.MidAirOrb;

        public override void BreakOrb(Rigidbody rb)
        {
            rb.linearVelocity = Swizzle.XOZ(rb.linearVelocity);
            rb.AddForce(Vector3.up * jumpDataHolder.jumpForce, ForceMode.Impulse);
        }
    }
}