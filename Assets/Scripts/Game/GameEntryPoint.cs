using Enemy;
using States;
using VContainer.Unity;

namespace Game
{
    public sealed class GameEntryPoint : IStartable
    {
        private readonly IStateService<EnemyContainer> stateService;

        public GameEntryPoint(IStateService<EnemyContainer> stateService)
        {
            this.stateService = stateService;
        }

        public void Start()
        {
            stateService.SetState<IdleEnemyState>();
        }
    }
}