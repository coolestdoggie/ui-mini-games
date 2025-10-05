using System;
using System.Collections.Generic;
using Common.Services;
using Common.States;
using Games.AceOfShadows.CodeBase.Infrastructure.Services;
using Games.AceOfShadows.CodeBase.UI.Services.Factory;

namespace Games.AceOfShadows.CodeBase.Infrastructure.States
{
    public class AceOfShadowsGameStateMachine : GameStateMachine
    {
        public AceOfShadowsGameStateMachine(AllServices services) : base(services) { }

        protected override void InitializeStates(AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<IConfigsService>(),
                    services.Single<IGameFactory>(), services.Single<ICardsService>()),
                [typeof(GameLoopState)] = new GameLoopState(this,services.Single<ITimeService>(),
                    services.Single<ICardsService>(), services.Single<IGameFactory>()),
                [typeof(EndState)] = new EndState(services.Single<IGameFactory>()),
            };
        }
    }
}