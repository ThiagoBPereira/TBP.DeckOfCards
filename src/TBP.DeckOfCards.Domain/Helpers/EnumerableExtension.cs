using System;
using System.Collections.Generic;
using System.Linq;

namespace TBP.DeckOfCards.Domain.Helpers
{
    /// <summary>
    /// Class to show how to create an extension function
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// Method to shuffle a generic list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">The collection </param>
        /// <returns></returns>
        public static IList<T> SuffleList<T>(this IList<T> list)
        {
            //In case of null or empty list, return the current list
            if (list?.Any() != true)
                return list;

            var random = new Random();

            for (int i = 0; i < list.Count; i++)
            {
                //Generating a random value with the maxvalue equal the list size
                var nextIndex = random.Next(list.Count);

                //Getting the current item
                var item = list[i];

                //Changing position inside the array
                list[i] = list[nextIndex];
                list[nextIndex] = item;
            }

            return list;
        }
    }
}
