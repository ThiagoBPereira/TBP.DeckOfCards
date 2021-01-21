using System.Collections.Generic;

namespace TBP.DeckOfCards.Domain.Interfaces
{
    public interface IDeck
    {
        IList<ICard> Cards { get; }
        int Total { get; }
        bool IsShuffled { get; }

        void Shuffle();
        public ICard Deal();
        void StartOver();
    }
}
