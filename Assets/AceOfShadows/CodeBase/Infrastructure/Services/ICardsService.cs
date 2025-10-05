using System;

namespace CodeBase.Services
{
    public interface ICardsService : IService
    {
        void InitDecks();
        event Action<int, int> CardMovedToRightDeck;
        int LeftDeckCarsAmount { get; }
        int RightDeckCardsAmount { get; }
    }
}