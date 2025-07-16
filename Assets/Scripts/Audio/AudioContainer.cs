using UnityEngine;

namespace Audio
{
    public sealed class AudioContainer : MonoBehaviour
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
    }
}