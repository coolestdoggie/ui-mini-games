using System;
using System.Collections.Generic;
using Common.Services;
using Common.States;
using Games.PhoenixFlame.CodeBase.Infrastructure.Services;

namespace Games.PhoenixFlame.CodeBase.Infrastructure.States
{
    public class PhoenixFlameGameStateMachine : GameStateMachine
    {
        public PhoenixFlameGameStateMachine(AllServices services) : base(services) {}
        
        protected override void InitializeStates(AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this, services.Single<IGameFactory>()),
                [typeof(EndState)] = new EndState(),
            };
        }
    }
}