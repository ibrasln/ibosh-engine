using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IboshEngine.Runtime.CollisionTrigger
{
    /// <summary>
    /// Monitors collisions with specified tags and triggers events on collision events.
    /// </summary>
    /// <remarks>
    /// This class, when attached to a GameObject with a Collider component, allows detection of collisions
    /// with GameObjects having specified tags. It provides UnityEvents for collision entry, continuous collision,
    /// and collision exit events, which can be linked to various actions in the Unity Editor.
    /// </remarks>
    [RequireComponent(typeof(Collider))]
    public class CollisionZone : MonoBehaviour
    {
        [SerializeField] private List<string> collisionTags = new();
        
        /// <summary>
        /// Event triggered when a collision begins.
        /// </summary>
        public UnityEvent OnCollisionEntered;

        /// <summary>
        /// Event triggered when a collision persists.
        /// </summary>
        public UnityEvent OnCollisionStayed;

        /// <summary>
        /// Event triggered when a collision ends.
        /// </summary>
        public UnityEvent OnCollisionExited;
        
        private void OnCollisionEnter(Collision other)
        {
            if (collisionTags.Count is 0) return;
            collisionTags.ForEach(t =>
            {
                if (other.gameObject.CompareTag(t)) OnCollisionEntered?.Invoke();
            });
        }

        private void OnCollisionStay(Collision other)
        {
            if (collisionTags.Count is 0) return;
            collisionTags.ForEach(t =>
            {
                if (other.gameObject.CompareTag(t)) OnCollisionStayed?.Invoke();
            });
        }

        private void OnCollisionExit(Collision other)
        {
            if (collisionTags.Count is 0) return;
            collisionTags.ForEach(t =>
            {
                if (other.gameObject.CompareTag(t)) OnCollisionExited?.Invoke();
            });
        }
    }
}
