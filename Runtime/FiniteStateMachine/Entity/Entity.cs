using UnityEngine;

namespace IboshEngine.Runtime.FiniteStateMachine.Entity  
{
    public abstract class Entity : MonoBehaviour
    {
        public Animator Anim { get; private set; }

        protected virtual void Awake()
        {
            Anim = GetComponent<Animator>();
        }
    }
}