using UnityEngine;

namespace Environment
{
    public class EnvironmentContainer : MonoBehaviour
    {
        [field: SerializeField] public Transform XRayTransform { get; private set; }
    }
}