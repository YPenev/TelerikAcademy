namespace Santase.Logic.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public static class EnumerableExtensions
    {
        /// <summary>
        /// Shuffle algorithm as seen on page 32 in the book "Algorithms" (4th edition) by Robert Sedgewick
        /// </summary>
        /// <param name="source">Collection to shuffle.</param>
        /// <typeparam name="T">The generic type parameter of the collection.</typeparam>
        /// <returns>The shuffled collection as IEnumerable.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var array = source.ToArray();
            var n = array.Length;
            for (var i = 0; i < n; i++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                var r = i + RandomProvider.Next(0, n - i);
                var temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }

            return array;
        }
    }

    public static class PlayerPositionExtensions
    {
        public static PlayerPosition OtherPlayer(this PlayerPosition playerPosition)
        {
            switch (playerPosition)
            {
                case PlayerPosition.FirstPlayer:
                    return PlayerPosition.SecondPlayer;
                case PlayerPosition.SecondPlayer:
                    return PlayerPosition.FirstPlayer;
                case PlayerPosition.NoOne:
                    return PlayerPosition.NoOne;
                default:
                    throw new ArgumentException("Invalid PlayerPosition value", nameof(playerPosition));
            }
        }
    }

    public static class RandomProvider
    {
        private static readonly ThreadLocal<Random> Random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        private static int seed = Environment.TickCount;

        public static int Next(int minValue, int maxValue)
        {
            return Random.Value.Next(minValue, maxValue);
        }
    }
}