namespace States
{
    public interface IStateService<out TBlackboard>
        where TBlackboard : IBlackboard
    {
        public void SetState<TState>() where TState : IState<TBlackboard>;
        public void SetState<TState, TPayload>(TPayload payload) where TState : IState<TBlackboard>;
    }
}