namespace IboshEngine.Runtime.FiniteStateMachine.Entity
{
    public class EntityStateMachine<T1, T2> where T1 : Entity where T2 : EntityData
    {
        public EntityState<T1, T2> CurrentState { get; private set; }
        public EntityState<T1, T2> PreviousState { get; private set; }

        public void Initialize(EntityState<T1, T2> startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(EntityState<T1, T2> newState)
        {
            CurrentState.Exit();
            PreviousState = CurrentState;
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}