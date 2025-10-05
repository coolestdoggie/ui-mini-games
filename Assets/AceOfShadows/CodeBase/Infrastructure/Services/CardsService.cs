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
        public event Action AllCardsMovedToRight;

        public int LeftDeckCardsAmount { get; private set; }
        public int RightDeckCardsAmount { get; private set; }

        private readonly IGameFactory _gameFactory;
        private readonly ITimeService _timeService;
        private readonly Stack<GameObject> _leftDeckCards = new();
        private readonly Stack<GameObject> _rightDeckCards = new();
        private GameObject _tempCard;

        private const float DeckYOffset = 12f;
        private const int RealCardsThreshold = 5;
        private const int InitialCardsAmount = 33;

        public CardsService(IGameFactory gameFactory, ITimeService timeService)
        {
            _gameFactory = gameFactory;
            _timeService = timeService;
            
            _timeService.SecondTick += MoveCardFromLeftToRight;
        }

        public void Init()
        {
            InitializeLeftDeck();
            InitializeTempCard();
        }

        private void InitializeLeftDeck()
        {
            float currentOffset = 0;
            for (int i = 0; i < InitialCardsAmount; i++)
            {
                if (i < RealCardsThreshold)
                {
                    CreateAndPositionCard(currentOffset);
                    currentOffset += DeckYOffset;
                }

                LeftDeckCardsAmount++;
            }

            RightDeckCardsAmount = 0;
        }

        private void CreateAndPositionCard(float yOffset)
        {
            GameObject card = _gameFactory.CreateCard();
            card.transform.SetParent(_gameFactory.HudFacade.LeftDeckTransform, false);
            card.transform.localPosition = new Vector3(0, card.transform.localPosition.y - yOffset, 0);
            _leftDeckCards.Push(card);
        }

        private void InitializeTempCard()
        {
            _tempCard = _gameFactory.CreateCard();
            _tempCard.transform.SetParent(_gameFactory.HudFacade.transform, false);
            _tempCard.SetActive(false);
        }

        private void MoveCardFromLeftToRight(int _)
        {
            if (LeftDeckCardsAmount <= 0)
            {
                Debug.Log("[CardsService] Left deck is empty. Stopping card movement.");
                _timeService.SecondTick -= MoveCardFromLeftToRight;
                AllCardsMovedToRight?.Invoke();
                return;
            }

            HandleCardMovement();
            CardMovedToRightDeck?.Invoke(LeftDeckCardsAmount, RightDeckCardsAmount);
        }

        private void HandleCardMovement()
        {
            if (LeftDeckCardsAmount <= RealCardsThreshold && RightDeckCardsAmount <= RealCardsThreshold)
                MoveRealCard();
            else if (LeftDeckCardsAmount > RealCardsThreshold && RightDeckCardsAmount < RealCardsThreshold)
                CreateAndMoveNewCard();
            else if (LeftDeckCardsAmount <= RealCardsThreshold && RightDeckCardsAmount >= RealCardsThreshold)
                RepositionRealCard();
            else
                MoveFakeCard();
        }

        private void MoveRealCard()
        {
            GameObject card = _leftDeckCards.Pop();
            UpdateDeckCounts();
            MoveCardToRightDeck(card);
        }

        private void CreateAndMoveNewCard()
        {
            GameObject newCard = _gameFactory.CreateCard();
            newCard.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform, false);
            newCard.transform.position = _leftDeckCards.Peek().transform.position;
            UpdateDeckCounts();
            MoveCardToRightDeck(newCard);
            _rightDeckCards.Push(newCard);
        }

        private void RepositionRealCard()
        {
            GameObject card = _leftDeckCards.Pop();
            UpdateDeckCounts();
            card.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform);
            
            AnimateCardMovement(card,
                _rightDeckCards.Count > 0 ? _rightDeckCards.Peek().transform.localPosition : Vector3.zero);
        }

        private void MoveFakeCard()
        {
            UpdateDeckCounts();
            _tempCard.transform.position = _leftDeckCards.Peek().transform.position;
            _tempCard.SetActive(true);
            AnimateCardMovement(_tempCard, _rightDeckCards.Peek().transform.position, () => _tempCard.SetActive(false));
        }

        private void UpdateDeckCounts()
        {
            LeftDeckCardsAmount--;
            RightDeckCardsAmount++;
        }

        private void MoveCardToRightDeck(GameObject card)
        {
            card.transform.SetParent(_gameFactory.HudFacade.RightDeckTransform);
            Vector3 targetPosition = _rightDeckCards.Count > 0
                ? _rightDeckCards.Peek().transform.localPosition - new Vector3(0, DeckYOffset, 0)
                : Vector3.zero;
            AnimateCardMovement(card, targetPosition);
            _rightDeckCards.Push(card);
        }

        private void AnimateCardMovement(GameObject card, Vector3 targetPosition, Action onComplete = null)
        {
            if (onComplete != null)
                card.transform.DOMove(targetPosition, 0.5f).OnComplete(() => onComplete());
            else
                card.transform.DOLocalMove(targetPosition, 0.5f);
        }
    }
}