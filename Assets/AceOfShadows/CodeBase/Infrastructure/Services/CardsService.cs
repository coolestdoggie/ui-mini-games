using System;
using System.Collections.Generic;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.Services
{
    public class CardsService : ICardsService
    {
        public event Action<int, int> CardMovedToRightDeck;
        
        private readonly IGameFactory _gameFactory;
        private readonly ITimeService _timeService;
        private Stack<GameObject> _leftDeckCards = new();
        private Stack<GameObject> _rightDeckCards = new();
        private const float deckYOffset  = 12;

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
                _timeService.SecondTick -= MoveLastCardFromLeftDeckToRight;
                return;
            }
            
            GameObject poppedCard = _leftDeckCards.Pop();
            
            GameObject rightDeckLastCard = null;
            if (_rightDeckCards.Count > 0)
                rightDeckLastCard = _rightDeckCards.Peek();
            
            _rightDeckCards.Push(poppedCard);
            
            poppedCard.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform, false);
            
            if (rightDeckLastCard != null)
                poppedCard.transform.localPosition = rightDeckLastCard.transform.localPosition - new Vector3(0, deckYOffset, 0);
            else
                poppedCard.transform.localPosition = Vector2.zero;
            
            CardMovedToRightDeck?.Invoke(_leftDeckCards.Count, _rightDeckCards.Count);
        }

        public void CreateLeftDeck()
        {
            float currentOffset = 0;
            for (int i = 0; i < 10; i++)
            {
                GameObject card = _gameFactory.CreateCard();
                card.transform.SetParent(_gameFactory.HudFacade.LeftDeckTransform, false);
                card.transform.localPosition = new Vector3(0, card.transform.localPosition.y - currentOffset, 0);

                _leftDeckCards.Push(card);

                currentOffset += deckYOffset;
            }
        }
    }
}