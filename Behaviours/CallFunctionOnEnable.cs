using Assets.Utility.Synchronized;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Utility
{
    public class CallFunctionOnEnable : SynchronizedMonoBehaviour
    {
        [SerializeField] private UnityEvent _function;

        public void OnEnable()
        {
            _function.Invoke();
        }
    }
}