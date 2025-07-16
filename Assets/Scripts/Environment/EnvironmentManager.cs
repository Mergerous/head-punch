using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace Environment
{
    [UsedImplicitly]
    public sealed class EnvironmentManager : IEnvironmentService
    {
        private readonly EnvironmentContainer container;
        private Sequence sequence;
        public EnvironmentManager(EnvironmentContainer container)
        {
            this.container = container;
        }
        
        public void EnableXRay()
        {
            sequence?.Kill();
            
            sequence = DOTween.Sequence()
                .Append(container.XRayTransform
                    .DOScale(Vector3.one * 4f, 1f)
                    .SetEase(Ease.InOutBack))
                .AppendInterval(1f)
                .Append(container.XRayTransform
                    .DOScale(Vector3.zero, 1f)
                    .SetEase(Ease.InOutBack))
                .SetLink(container.XRayTransform.gameObject);
        }
    }
}