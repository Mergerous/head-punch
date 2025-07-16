namespace States
{
    public interface IState<in TBlackboard>
        where TBlackboard : IBlackboard
    {
        TBlackboard Blackboard { set; }
        
        void OnEnter();

        void OnExit();
    }

    public interface IState<in TBlackboard, in TPayload> : IState<TBlackboard>
        where TBlackboard : IBlackboard
    {
        TPayload Payload { set; }
    }
}