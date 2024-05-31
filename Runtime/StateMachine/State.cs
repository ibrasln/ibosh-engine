using UnityEngine;

namespace IboshEngine.Runtime.StateMachine
{
    public abstract class State
    {
        protected float startingTime;
        protected StateMachine stateMachine;
        protected bool isAnimationFinished;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public virtual void Enter()
        {
            startingTime = Time.time;
            isAnimationFinished = false;
            DoChecks();
        }
        
        public virtual void Exit()
        {
            
        }
        
        public virtual void DoChecks()
        {
            
        }
        
        public virtual void LogicUpdate()
        {
            
        }
        
        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
    }
    
    public abstract class State<T1> : State where T1: MonoBehaviour 
    {
        protected T1 obj;
        protected new StateMachine<T1> stateMachine;
        protected string animBoolName;

        protected State(T1 obj, StateMachine<T1> stateMachine, string animBoolName) : base(stateMachine)
        {
            this.obj = obj;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
        }

        public override void Enter()
        {
            base.Enter();
        }
        
        public override void Exit()
        {
            base.Exit();
        }
        
        public override void DoChecks()
        {
            base.DoChecks();
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
        
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
    
    public abstract class State<T1, T2> : State<T1> where T1: MonoBehaviour where T2: ScriptableObject 
    {
        protected T2 objData;
        protected new StateMachine<T1, T2> stateMachine;

        protected State(T1 obj, StateMachine<T1, T2> stateMachine, T2 objData, string animBoolName) : base(obj, stateMachine, animBoolName)
        {
            this.obj = obj;
            this.objData = objData;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
        }
        
        public override void Enter()
        {
            base.Enter();
        }
        
        public override void Exit()
        {
            base.Exit();
        }
        
        public override void DoChecks()
        {
            base.DoChecks();
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
        
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}