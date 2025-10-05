using System;
using System.Collections.Generic;
using Common.Services;
using Common.States;
using MagicWords.CodeBase.Infrastructure.Services;

namespace MagicWords.CodeBase.Infrastructure.States
{
    public class MagicWordsGameStateMachine : GameStateMachine
    {
        public MagicWordsGameStateMachine(AllServices services) : base(services)
        {
        }
        
        protected override void InitializeStates(AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<IGameFactory>(),
                    services.Single<IDialogueFetchService>(), services.Single<IDialogueCreatorService>()),
                // [typeof(GameLoopState)] = new GameLoopState(this,services.Single<ITimeService>(),
                //     services.Single<ICardsService>(), services.Single<IGameFactory>()),
                // [typeof(EndState)] = new EndState(services.Single<IGameFactory>()),
            };
        }
    }
}