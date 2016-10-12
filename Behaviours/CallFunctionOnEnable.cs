using Assets.Utility.Synchronized;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Utility.Behaviours
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