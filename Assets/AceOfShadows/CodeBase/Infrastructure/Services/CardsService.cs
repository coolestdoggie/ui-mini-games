using System.Collections.Generic;
using System.Linq;
using CodeBase.UI.Services.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services
{
    public class DeckData
    {
    }

    public class CardsService : ICardsService
    {
        private readonly IGameFactory _gameFactory;
        private readonly ITimeService _timeService;
        private Stack<GameObject> _leftDeckCards = new();
        private Stack<GameObject> _rightDeckCards = new();

        public CardsService(IGameFactory gameFactory, ITimeService timeService)
        {
            _gameFactory = gameFactory;
            _timeService = timeService;

            _timeService.SecondTick += MoveLastCardFromLeftDeckToRight;
        }

        private void MoveLastCardFromLeftDeckToRight(int _)
        {
            if (_leftDeckCards.Count <= 0)
            {
                Debug.Log("[CardsService] Deck is Empty, moving is ignored");
                return;
            }
            
            GameObject card = _leftDeckCards.Pop();

            GameObject rightDeckLastCard = null;
            if (_rightDeckCards.Count > 0)
            {
                rightDeckLastCard = _rightDeckCards.Peek();
            }
            
            _rightDeckCards.Push(card);
            card.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform, false);

            if (rightDeckLastCard != null)
            {
                card.transform.localPosition = rightDeckLastCard.transform.localPosition + new Vector3(0, -12, 0);
            }
            else
            {
                card.transform.localPosition = Vector2.zero;
            }
        }

        public void CreateLeftDeck()
        {
            const float yOffset = 12;
            float currentOffset = 0;
            for (int i = 0; i < 10; i++)
            {
                GameObject card = _gameFactory.CreateCard();
                card.transform.SetParent(_gameFactory.HudFacade.LeftDeckTransform, false);
                card.transform.localPosition = new Vector3(0, card.transform.localPosition.y - currentOffset, 0);

                _leftDeckCards.Push(card);

                currentOffset += yOffset;
            }
        }
    }
}