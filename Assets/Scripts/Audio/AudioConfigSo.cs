using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = nameof(AudioConfigSo), menuName = "Configs/" + nameof(AudioConfigSo))]
    public sealed class AudioConfigSo : ScriptableObject
    {
        [SerializeField] private AudioClip[] clips;

        public IReadOnlyList<AudioClip> Clips => clips;
    }
}