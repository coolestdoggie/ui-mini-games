using AceOfShadows.CodeBase.DecksConfig;

namespace CodeBase.Services
{
    public interface IConfigsService : IService
    {
        DecksConfig DecksConfig { get; }
        void LoadConfigs();
    }
}