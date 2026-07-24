using JdnUtilities;
using UnityEngine;

namespace JdnUniPlat.Orbs
{
    public abstract class Ab_Orb : Collectable
    {
        [SerializeField] private MonoBehaviour orbStackUnv;
       
        private IOrbStack orbStack;


        public abstract JdnOrbs OrbType { get; }

        public abstract void BreakOrb(Rigidbody rb);
            
        private void HandlePickup(Collectable collectedOrb)
        {
            orbStack?.PushOrb(this);
        }

        private void Awake()
        {
            JdnValidate.ValidateInterface(orbStackUnv, out orbStack);
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