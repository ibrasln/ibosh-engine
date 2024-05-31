using System.Collections.Generic;
using IboshEngine.Runtime.Debugger;
using Random = UnityEngine.Random;

namespace IboshEngine.Runtime.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Determines whether the specified list is null or has a length of zero.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to check.</param>
        /// <returns>
        /// True if the list is null or has a length of zero; otherwise, false.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            if (list is null)
            {
                IboshDebugger.LogError("The list is null!", "List Extensions", IboshDebugger.DebugColor.White, IboshDebugger.DebugColor.Red);
                return true;
            }
            if (list.Count == 0)
            {
                IboshDebugger.LogError("The list is empty!", "List Extensions", IboshDebugger.DebugColor.White, IboshDebugger.DebugColor.Red);
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Randomly reorders the elements in the list using the Fisher-Yates shuffle algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to be shuffled. The list is modified in place.</param>
        public static void Shuffle<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty()) return;

            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                int randomIndex = Random.Range(i, count);
                (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
            }
        }
    }
}