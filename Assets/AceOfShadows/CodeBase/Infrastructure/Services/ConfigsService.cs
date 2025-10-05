using AceOfShadows.CodeBase.DecksConfig;
using UnityEngine;

namespace CodeBase.Services
{
    public class ConfigsService : IConfigsService
    {
        private const string DecksConfigPath = "AceOfShadows/DecksConfig";

        public DecksConfig DecksConfig { get; private set; }

        public void LoadConfigs()
        {
            DecksConfig = Resources.Load<DecksConfig>(DecksConfigPath);
        }
    }
}