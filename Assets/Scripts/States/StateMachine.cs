using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace States
{
    [UsedImplicitly]
    public sealed class StateMachine<TBlackboard> : IStateService<TBlackboard>
        where TBlackboard : IBlackboard
    {
        private readonly TBlackboard blackboard;
        private readonly IReadOnlyDictionary<Type, IState<TBlackboard>> states;
        private IState<TBlackboard> currentState;

        public StateMachine(TBlackboard blackboard, IEnumerable<IState<TBlackboard>> states)
        {
            this.blackboard = blackboard;
            this.states = states.ToDictionary(state => state.GetType(), state => state);
        }

        public void SetState<TState>()
            where TState : IState<TBlackboard>
        {
            if (states.TryGetValue(typeof(TState), out IState<TBlackboard> state))
            {
                currentState?.OnExit();
                SetState(state);
            }
        }
        
        public void SetState<TState, TPayload>(TPayload payload)
            where TState : IState<TBlackboard>
        {
            if (states.TryGetValue(typeof(TState), out IState<TBlackboard> state)
                && state is IState<TBlackboard, TPayload> targetState)
            {
                currentState?.OnExit();
                targetState.Payload = payload;
                SetState(targetState);
            }
        }

        private void SetState(IState<TBlackboard> state)
        {
            currentState = state;
            currentState.Blackboard = blackboard;
            currentState.OnEnter();
        }
    }
}
