using TBP.DeckOfCards.Domain.Enums;
using TBP.DeckOfCards.Domain.Interfaces;

namespace TBP.DeckOfCards.Domain
{
    /// <summary>
    /// The card entity
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        /// The card suit
        /// </summary>
        public CardSuitEnum Suit { get; private set; }

        /// <summary>
        /// The card value
        /// </summary>
        public CardValueEnum Value { get; private set; }

        public Card(CardSuitEnum suit, CardValueEnum value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
