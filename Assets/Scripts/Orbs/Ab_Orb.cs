using JdnUtilities;
using UnityEngine;

namespace JdnUniPlat.Orbs
{
    public abstract class Ab_Orb : Collectable
    {
        public abstract JdnOrbs OrbType { get; }
        protected abstract IOrbStack OrbStack { get; set; }


        public abstract void BreakOrb(Rigidbody rb);
            
        private void HandlePickup(Collectable collectedOrb)
        {
            OrbStack?.PushOrb(this);
        }



        private void OnEnable()
        {
            OnCollect += HandlePickup;
        }

        private void OnDisable()
        {
            OnCollect -= HandlePickup;
        }
    }
}