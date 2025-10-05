using Common.Services;

namespace Games.AceOfShadows.CodeBase.Infrastructure.Services
{
    public interface IConfigsService : IService
    {
        DecksConfig.DecksConfig DecksConfig { get; }
        void LoadConfigs();
    }
}