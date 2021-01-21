using FluentAssertions;
using System;
using System.Collections.Generic;
using TBP.DeckOfCards.Domain.Exceptions;
using TBP.DeckOfCards.Domain.Interfaces;
using Xunit;

namespace TBP.DeckOfCards.Domain.UnitTests
{
    public class DeckUnitTests
    {
        [Fact(DisplayName = "When instantiating a deck it must have one of each value card with one of each suit.")]
        [Trait("Category", "Deck")]
        public void Deck_Constructor_MustHaveTheCorrectNumberOfCards()
        {
            //Arrange
            //TODO Create correct list of cards, in the correct order

            //Action
            var deck = new Deck();

            //Assert
            deck.Cards
                .Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(52)
                .And.OnlyHaveUniqueItems(k => new { k.Suit, k.Value })
                .And.BeInAscendingOrder(k => k.Suit)
                .And.ThenBeInAscendingOrder(k => k.Value);

            deck.IsShuffled
                .Should()
                .BeFalse();
        }

        [Fact(DisplayName = "When shuffle a deck, the list of cards must not be in the same order")]
        [Trait("Category", "Deck")]
        public void Deck_Shuffle_MustShuffleTheCards()
        {
            //Arrange
            var deck = new Deck();
            var orderedCards = new List<ICard>(deck.Cards);

            //Action
            deck.Shuffle();

            //Assert
            deck.Cards
                .Should()
                .NotContainInOrder(orderedCards);

            deck.IsShuffled
                .Should()
                .BeTrue();
        }

        [Fact(DisplayName = "When trying to shuffle a deck with less than 52 cards, must throw an exception")]
        [Trait("Category", "Deck")]
        public void Deck_Shuffle_MustThrowMissingCardsException()
        {
            //Arrange
            var deck = new Deck();

            //Removing 1 card
            deck.Deal();

            //Action
            Action dealACard = () => deck.Shuffle();

            //Assert
            dealACard
                .Should()
                .Throw<MissingCardsException>();
        }

        [Fact(DisplayName = "When deal from the deck, the item must be removed from the list of cards")]
        [Trait("Category", "Deck")]
        public void Deck_Deal_MustRemoveItemFromListOfCards()
        {
            //Arrange
            var deck = new Deck();

            //Action
            var dealCard = deck.Deal();

            //Assert
            deck.Cards
                .Should()
                .NotContain(dealCard);
        }

        [Fact(DisplayName = "When deal from the deck and there are no cards it must throw an exception")]
        [Trait("Category", "Deck")]
        public void Deck_DealAndItHasNoCards_MustThrowMissingCardsException()
        {
            //Arrange
            var deck = new Deck();

            //Removing all cards
            while (deck.Cards.Count > 0)
            {
                deck.Deal();
            }

            //Action
            Action dealACard = () => deck.Deal();

            //Assert
            dealACard
                .Should()
                .Throw<MissingCardsException>();
        }

        [Fact(DisplayName = "When start over the deck, the cards list must be ordered as new")]
        [Trait("Category", "Deck")]
        public void Deck_StartOver_MustOrderTheCardsAgain()
        {
            //Arrange
            var deck = new Deck();
            deck.Shuffle();

            //Act
            deck.StartOver();

            //Assert
            deck.IsShuffled
                .Should()
                .BeFalse();
  
            deck.Cards
                .Should()
                .NotBeNullOrEmpty()
                .And.HaveCount(52)
                .And.OnlyHaveUniqueItems(k => new { k.Suit, k.Value })
                .And.BeInAscendingOrder(k => k.Suit)
                .And.ThenBeInAscendingOrder(k => k.Value);
        }
    }
}
