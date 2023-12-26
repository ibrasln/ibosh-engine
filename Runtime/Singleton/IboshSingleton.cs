using UnityEngine;

namespace IboshEngine.Runtime.Singleton
{
    using Debugger;
    
    [DefaultExecutionOrder(-5)]
    public class IboshSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        public virtual void Awake()
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
