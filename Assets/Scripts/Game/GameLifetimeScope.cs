using Audio;
using Cameras;
using Enemy;
using Environment;
using Punches;
using States;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Vfx;

namespace Game
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private EnemyContainer enemyContainer;
        [SerializeField] private EnvironmentContainer environmentContainer;
        [SerializeField] private AudioContainer audioContainer;
        [SerializeField] private AudioConfigSo audioConfig;
        [SerializeField] private VfxContainer vfxContainer;
        [SerializeField] private PunchConfigSo punchConfig;
        [SerializeField] private CameraContainer cameraContainer;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterEntryPoint<GameEntryPoint>();

            builder.Register<IAudioService, AudioManager>(Lifetime.Singleton)
                .WithParameter(audioContainer)
                .WithParameter(audioConfig);
            
            builder.Register<ICameraService, CameraManager>(Lifetime.Singleton).WithParameter(cameraContainer);
            builder.Register<IPunchService, PunchManager>(Lifetime.Singleton).WithParameter(punchConfig);
            builder.Register<IVfxService, VfxManager>(Lifetime.Singleton).WithParameter(vfxContainer);
            builder.Register<IEnvironmentService, EnvironmentManager>(Lifetime.Singleton).WithParameter(environmentContainer);

            builder.Register<IStateService<EnemyContainer>, StateMachine<EnemyContainer>>(Lifetime.Singleton)
                .WithParameter(enemyContainer);
            
            builder.Register<IState<EnemyContainer>, IdleEnemyState>(Lifetime.Singleton);
            builder.Register<IState<EnemyContainer>, PunchEnemyState>(Lifetime.Singleton);
        }
    }
}