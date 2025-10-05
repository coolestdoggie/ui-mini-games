using System;
using System.Collections.Generic;
using CodeBase.UI.Services.Factory;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Services
{
    public class CardsService : ICardsService
    {
        public event Action<int, int> CardMovedToRightDeck;
        
        public int LeftDeckCardsAmount { get; private set; }
        public int RightDeckCardsAmount { get; private set; }
        
        private readonly IGameFactory _gameFactory;
        private readonly ITimeService _timeService;
        
        private Stack<GameObject> _leftDeckCards = new();
        private Stack<GameObject> _rightDeckCards = new();
        private GameObject _tempCard;
        
        private const float DeckYOffset  = 12;
        private const int RealCardsThreshold = 5;
        private const int InitialCardsAmount = 144;

        public CardsService(IGameFactory gameFactory, ITimeService timeService)
        {
            _gameFactory = gameFactory;
            _timeService = timeService;

            _timeService.SecondTick += MoveLastCardFromLeftDeckToRight;
        }

        public void Init()
        {
            InitDecks();
            InitTempCard();
        }

        private void InitDecks()
        {
            float currentOffset = 0;
            for (int i = 0; i < InitialCardsAmount; i++)
            {
                var needToSpawnRealCard = i < RealCardsThreshold;
                if (needToSpawnRealCard)
                {
                    GameObject card = _gameFactory.CreateCard();
                    card.transform.SetParent(_gameFactory.HudFacade.LeftDeckTransform, false);
                    card.transform.localPosition = new Vector3(0, card.transform.localPosition.y - currentOffset, 0);

                    _leftDeckCards.Push(card);
                    LeftDeckCardsAmount++;

                    currentOffset += DeckYOffset;
                }
                else
                {
                    LeftDeckCardsAmount++;
                }
            }

            RightDeckCardsAmount = 0;
        }

        private void InitTempCard()
        {
            _tempCard = _gameFactory.CreateCard();
            _tempCard.transform.SetParent(_gameFactory.HudFacade.transform, false);
            _tempCard.SetActive(false);
        }

        private void MoveLastCardFromLeftDeckToRight(int _)
        {
            if (LeftDeckCardsAmount <= 0)
            {
                Debug.Log("[CardsService] Deck is Empty, moving is ignored");
                _timeService.SecondTick -= MoveLastCardFromLeftDeckToRight;
                return;
            }

            if (LeftDeckCardsAmount < RealCardsThreshold && RightDeckCardsAmount < RealCardsThreshold)
                MoveRealCardsFromLeftDeck();
            else if (LeftDeckCardsAmount >= RealCardsThreshold && RightDeckCardsAmount < RealCardsThreshold)
                InstantiateRealCardForRightDeck();
            else if (LeftDeckCardsAmount <= RealCardsThreshold && RightDeckCardsAmount >= RealCardsThreshold)
                MoveRealCardToRightDeckPosition();
            else
                MoveFakeCards();

            CardMovedToRightDeck?.Invoke(LeftDeckCardsAmount, RightDeckCardsAmount);
        }

        private void MoveRealCardsFromLeftDeck()
        {
            GameObject poppedCard = _leftDeckCards.Pop();
            LeftDeckCardsAmount--;
            
            GameObject rightDeckLastCard = null;
            if (_rightDeckCards.Count > 0)
                rightDeckLastCard = _rightDeckCards.Peek();
            
            _rightDeckCards.Push(poppedCard);
            RightDeckCardsAmount++;
            
            poppedCard.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform, false);

            if (rightDeckLastCard != null)
            {
                poppedCard.transform.DOLocalMove(rightDeckLastCard.transform.localPosition - new Vector3(0, DeckYOffset, 0), 0.5f);
            }
            else
                poppedCard.transform.localPosition = Vector2.zero;
        }

        private void InstantiateRealCardForRightDeck()
        {
            var lastRealCardInLeftDeck = _leftDeckCards.Peek();
            
            var newCard = _gameFactory.CreateCard();
            newCard.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform, false);
            newCard.transform.position = lastRealCardInLeftDeck.transform.position;
            LeftDeckCardsAmount--;
            
            GameObject rightDeckLastCard = null;
            if (_rightDeckCards.Count > 0)
                rightDeckLastCard = _rightDeckCards.Peek();
            
            _rightDeckCards.Push(newCard);
            RightDeckCardsAmount++;

            if (rightDeckLastCard != null)
                newCard.transform.DOLocalMove(rightDeckLastCard.transform.localPosition - new Vector3(0, DeckYOffset, 0), 0.5f);
            else
                newCard.transform.DOLocalMove(Vector2.zero, 0.5f);
        }

        private void MoveRealCardToRightDeckPosition()
        {
            GameObject poppedCard = _leftDeckCards.Pop();
            LeftDeckCardsAmount--;
            
            GameObject rightDeckLastCard = null;
            if (_rightDeckCards.Count > 0)
                rightDeckLastCard = _rightDeckCards.Peek();
            
            RightDeckCardsAmount++;
            
            poppedCard.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform);
            if (rightDeckLastCard != null)
                poppedCard.transform.DOMove(rightDeckLastCard.transform.position, 0.5f);
        }

        private void MoveFakeCards()
        {
            var lastRealCardInLeftDeck = _leftDeckCards.Peek();
            var lastRealCardInRightDeck = _rightDeckCards.Peek();
            
            _tempCard.transform.position = lastRealCardInLeftDeck.transform.position;
            _tempCard.SetActive(true);
            _tempCard.transform
                .DOMove(lastRealCardInRightDeck.transform.position, 0.5f)
                .OnComplete(() => _tempCard.SetActive(false));
            
            
            LeftDeckCardsAmount--;
            RightDeckCardsAmount++;
        }
    }
}