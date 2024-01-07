using UnityEngine;

namespace IboshEngine.Runtime.Singleton
{
    using Debugger;

    /// <summary>
    /// Abstract base class for creating singletons in Unity.
    /// </summary>
    /// <typeparam name="T">The type of the singleton instance.</typeparam>
    /// <remarks>
    /// This class provides a basic implementation for creating singletons. It ensures that only one instance of the derived class exists.
    /// </remarks>
    [DefaultExecutionOrder(-5)]
    public abstract class IboshSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                IboshDebugger.LogError($"There is an instance of the {typeof(T).FullName}", "IboshSingleton", IboshDebugger.DebugColor.Red, IboshDebugger.DebugColor.Black);

                if (Instance.gameObject) Destroy(Instance.gameObject);
                Instance = this as T;
            }
        }
    }
}
