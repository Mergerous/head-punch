using UnityEngine;

namespace Cameras
{
    public sealed class CameraContainer : MonoBehaviour
    {
        [field: SerializeField] public Animator StateDrivenCameraAnimator { get; private set; }
    }
}