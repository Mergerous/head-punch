using Audio;
using Cameras;
using DG.Tweening;
using Environment;
using JetBrains.Annotations;
using Punches;
using States;
using UnityEngine;
using Vfx;
using CameraType = Cameras.CameraType;

namespace Enemy
{
    [UsedImplicitly]
    public sealed class PunchEnemyState : IState<EnemyContainer, PunchEnemyPayload>
    {
        private readonly IPunchService punchService;
        private readonly IVfxService vfxService;
        private readonly IAudioService audioService;
        private readonly IEnvironmentService environmentService;
        private readonly ICameraService cameraService;

        private Tween tween;
        private int count;
        
        public PunchEnemyPayload Payload { private get; set; }
        public EnemyContainer Blackboard { private get; set; }

        public PunchEnemyState(IPunchService punchService, IVfxService vfxService, 
            IAudioService audioService, IEnvironmentService environmentService, ICameraService cameraService)
        {
            this.punchService = punchService;
            this.vfxService = vfxService;
            this.audioService = audioService;
            this.environmentService = environmentService;
            this.cameraService = cameraService;
        }

        public void OnEnter()
        {
            tween?.Kill();
            tween = Blackboard.Transform
                .DOPunchScale(Vector3.one * 2f, 1, 4, 0.4f)
                .OnKill(() => Blackboard.Transform.localScale = Vector3.one)
                .SetLink(Blackboard.Transform.gameObject);
            
            PunchConfig itemConfig = punchService.GetPunchConfig(count++);
            Blackboard.renderer.material = itemConfig.materialVariants[Random.Range(0, itemConfig.materialVariants.Length)];
            
            vfxService.PlayEffect(Payload.point);
            audioService.PlaySound();
            cameraService.SetCamera(CameraType.PunchCamera);

            float random = Random.Range(0f, 1f);
            if (random < itemConfig.xRayChance)
            {
                environmentService.EnableXRay();
            }
        }

        public void OnExit()
        {
        }
    }
}
