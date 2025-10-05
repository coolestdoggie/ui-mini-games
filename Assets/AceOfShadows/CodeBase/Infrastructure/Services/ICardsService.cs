using System;

namespace CodeBase.Services
{
    public interface ICardsService : IService
    {
        void CreateLeftDeck();
        event Action<int, int> CardMovedToRightDeck;
    }
}