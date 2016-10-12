using UnityEngine;

namespace Assets.Scripts.Utility.Synchronized
{
    /// <summary>
    /// MonoBehaviour with locks. Any access of an object should first be locked with SyncLock by the caller.
    /// Methods of the callee (the SynchronizedMonoBehaviour) should lock with _interalLock
    /// 
    /// This will ensure that only one thread can have access to the object at a time, and that the object can only
    /// access itself from one thread at a time
    /// </summary>
    public class SynchronizedMonoBehaviour : MonoBehaviour
    {
        public object SyncLock { get; private set; }    // Lock to use for synchronization of object's methods
        protected readonly object _internalLock;                 // Lock to use for synchronization inside of object's methods
        protected readonly object _mainThreadLock;               // Lock to use for synchronization with the main thread

        public SynchronizedMonoBehaviour()
        {
            SyncLock = new object();
            _internalLock = new object();
            _mainThreadLock = new Object();
        }
    }
}