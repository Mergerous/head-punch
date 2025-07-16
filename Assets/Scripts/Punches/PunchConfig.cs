using System;
using UnityEngine;

namespace Punches
{
    [Serializable]
    public struct PunchConfig
    {
        public int punchCount;
        [Range(0f, 1f)] public float xRayChance;
        public Material[] materialVariants;
    }
}