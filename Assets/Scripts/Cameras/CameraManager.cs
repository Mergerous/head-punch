using JetBrains.Annotations;
using UnityEngine;

namespace Cameras
{
    [UsedImplicitly]
    public sealed class CameraManager : ICameraService
    {
        private static readonly int TRIGGER = Animator.StringToHash("Trigger");
        private static readonly int CAMERA_TYPE = Animator.StringToHash("CameraType");
        
        private readonly CameraContainer container;

        public CameraManager(CameraContainer container)
        {
            this.container = container;
        }

        public void SetCamera(CameraType type)
        {
            container.StateDrivenCameraAnimator.SetInteger(CAMERA_TYPE, (int)type);
            container.StateDrivenCameraAnimator.SetTrigger(TRIGGER);
        }
    }
}