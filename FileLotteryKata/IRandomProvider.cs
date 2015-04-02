using System;
using System.Collections.Generic;

namespace FileLotteryKata
{
    public interface IRandomProvider
    {
        int[] GetDistinctRandomValues();
        int MaxIndex { get; set; }
    }

    public class RandomProvider : IRandomProvider
    {
        public int[] GetDistinctRandomValues()
        {
            var random = new Random();
            var randomDoubles = new double[MaxIndex + 1];
            var randomIntegers = new int[MaxIndex + 1];

            for (int i = 0; i <= MaxIndex; i++)
            {
                randomIntegers[i] = i;
                randomDoubles[i] = random.NextDouble();
            }

            Array.Sort(randomDoubles, randomIntegers);

            return randomIntegers;
        }

        public int MaxIndex { get; set; }
    }
}