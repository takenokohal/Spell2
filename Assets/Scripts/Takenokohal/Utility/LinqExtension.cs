using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Takenokohal.Utility
{
    public static class LinqExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> origin)
        {
            return origin.OrderBy(_ => Random.Range(0, int.MaxValue));
        }

        public static T GetRandomValue<T>(this IEnumerable<T> origin)
        {
            return origin.Shuffle().FirstOrDefault();
        }
    }
}