using IboshEngine.Runtime.Interfaces;
using UnityEngine;

namespace IboshEngine.Runtime.FiniteStateMachine.Entity
{
    public class EntityState<T1, T2> : ILogicUpdate where T1 : Entity where T2 : EntityData
    {
        
        //TODO: CREATE A SAMPLE FOR THE PLAYER.
        
        protected T1 entity;
        protected T2 entityData;
        protected EntityStateMachine<T1, T2> stateMachine;
        protected float startingTime;
        protected bool isAnimationFinished;
        private string _animBoolName;

        public EntityState(T1 entity, T2 entityData, EntityStateMachine<T1, T2> stateMachine, string animBoolName)
        {
            this.entity = entity;
            this.entityData = entityData;
            this.stateMachine = stateMachine;
            _animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            entity.Anim.SetBool(_animBoolName, true);
            startingTime = Time.time;
            isAnimationFinished = false;
            DoChecks();
        }

        public virtual void Exit()
        {
            
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            
        }

        public void AnimationFinishTrigger() => isAnimationFinished = true;
    }
}
