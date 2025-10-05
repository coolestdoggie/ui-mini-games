using Common.States;
using Games.AceOfShadows.CodeBase.UI.Services.Factory;

namespace Games.AceOfShadows.CodeBase.Infrastructure.States
{
    public class EndState : IState
    {
        private readonly IGameFactory _gameFactory;

        public EndState(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Enter() =>
            _gameFactory.HudFacade.SetActiveEndLabel(true);

        public void Exit() {}
    }
}