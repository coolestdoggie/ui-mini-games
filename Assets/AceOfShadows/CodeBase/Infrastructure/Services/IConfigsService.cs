using Common.Services;

namespace AceOfShadows.CodeBase.Infrastructure.Services
{
    public interface IConfigsService : IService
    {
        DecksConfig.DecksConfig DecksConfig { get; }
        void LoadConfigs();
    }
}