using System;

namespace CodeBase.Services
{
    public interface ICardsService : IService
    {
        void Init();
        event Action<int, int> CardMovedToRightDeck;
        int LeftDeckCardsAmount { get; }
        int RightDeckCardsAmount { get; }
    }
}