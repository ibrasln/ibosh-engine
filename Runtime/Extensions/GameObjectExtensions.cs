using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IboshEngine.Runtime.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Extension method to get all children of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject.</param>
        public static List<GameObject> GetChildren(this GameObject gameObject)
        {
            return (from Transform child in gameObject.transform select child.gameObject).ToList();
        }
        
        /// <summary>
        /// Extension method to set the active state of all children of the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject.</param>
        /// <param name="state">The new active state to set for all children.</param>
        public static void SetActiveChildren(this GameObject gameObject, bool state)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(state);     
            }
        }
    }
}
