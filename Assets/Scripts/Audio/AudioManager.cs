using JetBrains.Annotations;
using UnityEngine;

namespace Audio
{
    [UsedImplicitly]
    public sealed class AudioManager : IAudioService
    {
        private readonly AudioConfigSo config;
        private readonly AudioContainer container;

        public AudioManager(AudioConfigSo config, AudioContainer container)
        {
            this.config = config;
            this.container = container;
        }
        
        public void PlaySound()
        {
            AudioClip clip = config.Clips[Random.Range(0, config.Clips.Count)];
            container.AudioSource.clip = clip;
            container.AudioSource.Play();
        }
    }
}