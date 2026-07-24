using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JdnUniPlat.Orbs
{
    public class OrbStack : MonoBehaviour, IOrbStack
    {
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private InputActionReference breakOrbBinds;

        private Stack<Ab_Orb> _orbStack = new Stack<Ab_Orb>();
        private OrbStackUI orbStackUI;

        public void InjectData(OrbStackUI orbStackUI)
        {
            this.orbStackUI = orbStackUI;
        }

        public bool PopOrb()
        {
            if (_orbStack.Count > 0)
            {
                Ab_Orb orb = _orbStack.Pop();
                orb.BreakOrb(playerRigidbody);
                orbStackUI.RemoveOrb();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PushOrb(Ab_Orb orb)
        {
            _orbStack.Push(orb);
            orbStackUI.AddOrb(orb.OrbType);
        }

        private void BreakOrbHandle(InputAction.CallbackContext context)
        {
            if (PopOrb())
            {
                //Orb Succeded Effects
            }
            else
            {
                // Orb Failed effects 
            }
        }

        private void OnEnable()
        {
            breakOrbBinds.action.started += BreakOrbHandle;
        }
        private void OnDisable()
        {
            breakOrbBinds.action.started -= BreakOrbHandle;

        }
    }
}