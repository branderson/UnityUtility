using Assets.Scripts.Utility.Synchronized;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Utility
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