using System;

namespace TBP.DeckOfCards.Domain.Exceptions
{
    /// <summary>
    /// Showing inheritance implementation
    /// </summary>
    public class MissingCardsException : Exception
    {
        /// <summary>
        /// Custom message
        /// </summary>
        /// <param name="message">The exception message</param>
        public MissingCardsException(string message) : base(message)
        {
        }
    }
}
