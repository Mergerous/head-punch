using System.Linq;
using JetBrains.Annotations;

namespace Punches
{
    [UsedImplicitly]
    public sealed class PunchManager : IPunchService
    {
        private readonly PunchConfigSo config;

        public PunchManager(PunchConfigSo config)
        {
            this.config = config;
        }
        
        public PunchConfig GetPunchConfig(int punchCount)
        {
            return config.PunchConfigs
                .OrderBy(itemConfig => itemConfig.punchCount)
                .Last(itemConfig => itemConfig.punchCount <= punchCount);
        }
    }
}