using System;
using Cysharp.Threading.Tasks;

namespace AceOfShadows.CodeBase.Infrastructure.Services
{
    public class TimeService : ITimeService
    {
        public event Action<int> SecondTick;
        public int SecondsPassed { get; private set; }

        private bool _ticking;

        public async void StartTicking()
        {
            _ticking = true;
            while (_ticking)
            {
                await UniTask.Delay(1000);
                SecondsPassed++;
                SecondTick?.Invoke(SecondsPassed);
            }
        }

        public void StopTicking() => 
            _ticking = false;
    }
}