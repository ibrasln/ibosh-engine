using System;
using UnityEngine;

namespace IboshEngine.Runtime.StateMachine
{
    public class StateMachine
    {
        public Action OnStateChanged;
        public State CurrentState { get; private set; }
        public State PreviousState { get; private set; }

        public virtual void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
        }
    
        public virtual void ChangeState(State newState)
        {
            PreviousState = CurrentState;
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
        }
    }
    
    public class StateMachine<T1> : StateMachine where T1 : MonoBehaviour
    {
        public new State<T1> CurrentState { get; private set; }
        public new State<T1> PreviousState { get; private set; }

        public override void Initialize(State startingState)
        {
            if (startingState is not State<T1> state)
            {
                throw new ArgumentException("Starting state must be of type State<T1>.");
            }
            CurrentState = state;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
        }
    
        public override void ChangeState(State newState)
        {
            if (newState is not State<T1> state)
            {
                throw new ArgumentException("New state must be of type State<T1>.");
            }
            PreviousState = CurrentState;
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
        }
    }
    
    public class StateMachine<T1, T2> : StateMachine<T1> where T1 : MonoBehaviour where T2 : ScriptableObject
    {
        public new State<T1, T2> CurrentState { get; private set; }
        public new State<T1, T2> PreviousState { get; private set; }

        public override void Initialize(State startingState)
        {
            if (startingState is not State<T1, T2> state)
            {
                throw new ArgumentException("Starting state must be of type State<T1, T2>.");
            }
            CurrentState = state;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
        }
    
        public override void ChangeState(State newState)
        {
            if (newState is not State<T1, T2> state)
            {
                throw new ArgumentException("New state must be of type State<T1, T2>.");
            }
            PreviousState = CurrentState;
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
            OnStateChanged?.Invoke();
        }
    }
}