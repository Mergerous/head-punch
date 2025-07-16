using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vfx
{
    [Serializable]
    public class VfxConfig
    {
        public bool shouldChangePosition;
        public ParticleSystem particles;
    }
    
    public sealed class VfxContainer : MonoBehaviour
    {
        [SerializeField] private VfxConfig[] configs;
        public IReadOnlyList<VfxConfig> Configs => configs;
    }
}