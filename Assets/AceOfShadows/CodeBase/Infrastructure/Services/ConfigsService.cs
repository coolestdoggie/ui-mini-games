using UnityEngine;

namespace AceOfShadows.CodeBase.Infrastructure.Services
{
    public class ConfigsService : IConfigsService
    {
        private const string DecksConfigPath = "AceOfShadows/DecksConfig";

        public DecksConfig.DecksConfig DecksConfig { get; private set; }

        public void LoadConfigs()
        {
            DecksConfig = Resources.Load<DecksConfig.DecksConfig>(DecksConfigPath);
        }
    }
}