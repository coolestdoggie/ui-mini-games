using System;

namespace AceOfShadows.CodeBase.Infrastructure.Services
{
    public interface ITimeService : IService
    {
        event Action<int> SecondTick;
        int SecondsPassed { get; }
        void StartTicking();
        void StopTicking();
    }
}