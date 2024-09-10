using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    /// <summary>
    /// A utility class that automatically destroys a GameObject after a specified lifetime.
    /// </summary>
    /// <remarks>
    /// This class allows you to set a duration in seconds, after which the GameObject is destroyed.
    /// It uses Unity's Destroy method to remove the object from the scene.
    /// </remarks>
    public class Lifetime : MonoBehaviour
    {
        [SerializeField] private float lifetime;

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }
    }
}