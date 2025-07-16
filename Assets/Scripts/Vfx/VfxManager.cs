using JetBrains.Annotations;
using UnityEngine;

namespace Vfx
{
    [UsedImplicitly]
    public sealed class VfxManager : IVfxService
    {
        private readonly VfxContainer container;

        public VfxManager(VfxContainer container)
        {
            this.container = container;
            
        }
        public void PlayEffect(Vector3 effectPoint)
        {
            VfxConfig config = container.Configs[Random.Range(0, container.Configs.Count)];
            if (config.shouldChangePosition)
            {
                config.particles.transform.position = effectPoint;
            }
            config.particles.Play();
        }
    }
}