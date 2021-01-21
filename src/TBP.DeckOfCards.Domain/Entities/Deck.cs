using System;
using System.Collections.Generic;
using System.Linq;
using TBP.DeckOfCards.Domain.Enums;
using TBP.DeckOfCards.Domain.Exceptions;
using TBP.DeckOfCards.Domain.Helpers;
using TBP.DeckOfCards.Domain.Interfaces;

namespace TBP.DeckOfCards.Domain
{
    /// <summary>
    /// The deck entity
    /// </summary>
    public class Deck : IDeck
    {
        public int Total => Cards?.Count() ?? 0;
        public bool IsShuffled { get; private set; }

        /// <summary>
        /// List of cards
        /// </summary>
        public IList<ICard> Cards { get; private set; }

        public Deck()
        {
            //Initialize cards list
            Cards = new List<ICard>();

            //Reading cards
            ReadCards();
        }

        #region Publics

        /// <summary>
        /// Method to shuffle the deck, using random
        /// </summary>
        public void Shuffle()
        {
            if (Cards?.Count != 52)
                throw new MissingCardsException("To shuffle you need to have 52 cards on the deck.");

            //Execute IList extension method
            Cards.SuffleList();

            IsShuffled = true;
        }

        /// <summary>
        /// Method to deal a card
        /// </summary>
        public ICard Deal()
        {
            //No cards available
            if (Cards?.Any() != true)
                throw new MissingCardsException("There are no more cards.");

            //Removing card from the deck
            var card = Cards[0];
            Cards.Remove(card);

            return card;
        }

        /// <summary>
        /// Method to start over and order the deck
        /// </summary>
        public void StartOver()
        {
            //Clear list
            Cards.Clear();

            //Reading cars
            ReadCards();
        }
        #endregion

        #region Privates

        /// <summary>
        /// Method to generate/read the deck
        /// </summary>
        private void ReadCards()
        {
            //Read all "suits" values
            var suits = Enum.GetValues(typeof(CardSuitEnum));

            //read all "values" values
            var values = Enum.GetValues(typeof(CardValueEnum));

            //for each suit, we must have all values
            foreach (CardSuitEnum suit in suits)
            {
                foreach (CardValueEnum value in values)
                {
                    Cards.Add(new Card(suit, value));
                }
            }

            IsShuffled = false;
        }

        #endregion
    }
}
