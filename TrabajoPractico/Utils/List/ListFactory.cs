using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Utils.List
{
    public static class ListFactory
    {
        public static T GetRandomElement<T>(IList<T> collection)
        {
            var randomize = new Random();
            var randomElement = collection[randomize.Next(collection.Count())];

            return randomElement;
        }

        public static List<T> TotalRandomMix<T>(IList<T> list1, IList<T> list2)
        {
            var newMoves = new List<T>();
            var randomCross = new Random();

            int minLength = Math.Min(list1.Count, list2.Count);
            int maxLength = Math.Max(list1.Count, list2.Count);

            IList<T> maxList = list1.Count == maxLength ? list1 : list2;
            IList<T> minList = list1.Count == minLength ? list1 : list2;

            for (int i = 0; i < maxLength; i++)
            {
                bool isMaxList = randomCross.NextDouble() < 0.5;
                T tuple;

                if (isMaxList || i < minLength)
                {
                    tuple = isMaxList ? maxList[i] : minList[i];
                    newMoves.Add(tuple);
                }
            }

            return newMoves;
        }
    }
}
