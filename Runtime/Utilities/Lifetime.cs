using UnityEngine;

namespace IboshEngine.Runtime.Utilities
{
    public class Lifetime : MonoBehaviour
    {
        [SerializeField] private float lifetime;

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }
    }
}