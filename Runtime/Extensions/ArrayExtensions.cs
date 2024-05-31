using System;
using System.Linq;
using IboshEngine.Runtime.Debugger;
using Random = UnityEngine.Random;

namespace IboshEngine.Runtime.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Determines whether the specified array is null or has a length of zero.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to check.</param>
        /// <returns>
        /// True if the array is null or has a length of zero; otherwise, false.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            if (array is null)
            {
                IboshDebugger.LogError("The array is null!", "Array Extensions", IboshDebugger.DebugColor.White, IboshDebugger.DebugColor.Red);
                return true;
            }
            if (array.Length == 0)
            {
                IboshDebugger.LogError("The array is empty!", "Array Extensions", IboshDebugger.DebugColor.White, IboshDebugger.DebugColor.Red);
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Determines whether the specified array contains the specified value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <param name="value">The value to locate in the array.</param>
        /// <returns>
        /// True if the value is found in the array; otherwise, false.
        /// </returns>
        public static bool Contains<T>(this T[] array, T value)
        {
            if (array.IsNullOrEmpty())
            {
                
                return false;
            }

            return Enumerable.Contains(array, value);
        }
        
        /// <summary>
        /// Randomly reorders the elements in the array using the Fisher-Yates shuffle algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to be shuffled. The array is modified in place.</param>
        public static void Shuffle<T>(this T[] array)
        {
            if (array.IsNullOrEmpty()) return;
            
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                int randomIndex = Random.Range(i, count);
                (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
            }
        }
        
        /// <summary>
        /// Sets all elements in the specified array to their default value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to clear.</param>
        public static void Clear<T>(this T[] array)
        {
            if (array.IsNullOrEmpty()) return;

            Array.Clear(array, 0, array.Length);
        }
        
        /// <summary>
        /// Adds an element to the end of the specified array, then returns a new array with the element included.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to which the element will be added.</param>
        /// <param name="element">The element to add to the array.</param>
        /// <returns>A new array containing all elements of the original array, plus the new element.</returns>
        public static T[] Add<T>(this T[] array, T element)
        {
            if (array.IsNullOrEmpty()) return array;

            int length = array.Length;
            T[] newArray = new T[length + 1];
            Array.Copy(array, newArray, length);
            newArray[length] = element;
            
            return newArray;
        }
        
        /// <summary>
        /// Removes the first occurrence of the specified value from the array, returning a new array without that value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array from which to remove the value.</param>
        /// <param name="value">The value to remove from the array.</param>
        /// <returns>A new array containing all elements of the original array except the first occurrence of the specified value.</returns>
        public static T[] Remove<T>(this T[] array, T value)
        {
            if (array.IsNullOrEmpty()) return array;

            int index = Array.IndexOf(array, value);
            if (index == -1)
            {
                IboshDebugger.LogError("The value not found!", "Array Extensions", IboshDebugger.DebugColor.White, IboshDebugger.DebugColor.Red);
                return array;
            }

            return array.RemoveAt(index);
        }
        
        /// <summary>
        /// Removes the element at the specified index from the array, returning a new array without that element.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array from which to remove the element.</param>
        /// <param name="index">The index of the element to remove.</param>
        /// <returns>A new array containing all elements of the original array except the one at the specified index.</returns>
        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            if (array.IsNullOrEmpty()) return array;

            if (index < 0 || index >= array.Length)
            {
                IboshDebugger.LogError($"Index {index} is out of range. Cannot remove element.", "Array Extensions", IboshDebugger.DebugColor.White, IboshDebugger.DebugColor.Red);
                return array;
            }

            T[] newArray = new T[array.Length - 1];
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, array.Length - index - 1);

            return newArray;
        }
    }
}