using TBP.DeckOfCards.Domain.Enums;

namespace TBP.DeckOfCards.Domain.Interfaces
{
    public interface ICard
    {
        public CardSuitEnum Suit { get;  }
        public CardValueEnum Value { get;  }
    }
}
