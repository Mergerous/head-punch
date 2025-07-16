using JetBrains.Annotations;
using States;

namespace Enemy
{
    [UsedImplicitly]
    public sealed class IdleEnemyState : IState<EnemyContainer>
    {
        public EnemyContainer Blackboard { private get; set; }

        public void OnEnter()
        {
            // TODO Add enemy idle logic
        }

        public void OnExit()
        {
            
        }
    }
}
