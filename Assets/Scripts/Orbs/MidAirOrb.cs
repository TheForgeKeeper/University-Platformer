using JdnUtilities;
using UnityEngine;

namespace JdnUniPlat.Orbs
{
    public class MidAirOrb : Ab_Orb
    {
        [SerializeField] private float jumpForce = 7f;

        public override JdnOrbs OrbType => JdnOrbs.MidAirOrb;

        public override void BreakOrb(Rigidbody rb)
        {
            rb.linearVelocity = Swizzle.XOZ(rb.linearVelocity);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}