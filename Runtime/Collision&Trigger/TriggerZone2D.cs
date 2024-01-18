using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IboshEngine.Runtime.CollisionTrigger
{
    /// <summary>
    /// Monitors 2D trigger events with specified tags and triggers events on trigger events.
    /// </summary>
    /// <remarks>
    /// This class, when attached to a GameObject with a Collider2D component set as a trigger, allows detection of trigger events
    /// with GameObjects having specified tags. It provides UnityEvents for trigger entry, continuous trigger,
    /// and trigger exit events, which can be linked to various actions in the Unity Editor.
    /// </remarks>
    [RequireComponent(typeof(Collider2D))]
    public class TriggerZone2D : MonoBehaviour
    {
        [SerializeField] private List<string> collisionTags = new();
        
        /// <summary>
        /// Event triggered when a trigger begins.
        /// </summary>
        public UnityEvent OnTriggerEntered;

        /// <summary>
        /// Event triggered when a trigger persists.
        /// </summary>
        public UnityEvent OnTriggerStayed;

        /// <summary>
        /// Event triggered when a trigger ends.
        /// </summary>
        public UnityEvent OnTriggerExited;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (collisionTags.Count is 0) return;
            collisionTags.ForEach(t =>
            {
                if (other.CompareTag(t)) OnTriggerEntered?.Invoke();
            });
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (collisionTags.Count is 0) return;
            collisionTags.ForEach(t =>
            {
                if (other.CompareTag(t)) OnTriggerStayed?.Invoke();
            });
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (collisionTags.Count is 0) return;
            collisionTags.ForEach(t =>
            {
                if (other.CompareTag(t)) OnTriggerExited?.Invoke();
            });
        }
    }
}
