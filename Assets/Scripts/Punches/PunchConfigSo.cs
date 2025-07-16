using System.Collections.Generic;
using UnityEngine;

namespace Punches
{
    [CreateAssetMenu(fileName = nameof(PunchConfigSo), menuName = "Configs/" + nameof(PunchConfigSo))]
    public sealed class PunchConfigSo : ScriptableObject
    {
        [SerializeField] private PunchConfig[] punchConfigs;

        public IReadOnlyList<PunchConfig> PunchConfigs => punchConfigs;
    }
}