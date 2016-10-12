using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility.Pooling
{
    /// <summary>
    /// Pool for PooledMonoBehaviours
    /// </summary>
    public class MonoBehaviourPool : CustomMonoBehaviour
    {
        [SerializeField] private PooledMonoBehaviour _pooledPrefab;
        [SerializeField] protected List<IPoolable> _pooledObjects;
        private string _prefabString;

        public MonoBehaviourPool()
        {
            _pooledObjects = new List<IPoolable>();
        }

        /// <summary>
        /// Initialize the pool with instances
        /// </summary>
        /// <param name="initialInstances"></param>
        /// <param name="minInstances"></param>
        /// <param name="maxInstances"></param>
        public void Initialize(int initialInstances, int minInstances = 0, int maxInstances = 0)
        {
            
        }

        /// <summary>
        /// Get the pool for the given prefab's type, creating one if it does not yet exist
        /// </summary>
        /// <param name="prefab">
        /// Prefab to get pool for
        /// </param>
        /// <returns>
        /// Pool for given type
        /// </returns>
        public static MonoBehaviourPool GetPool(PooledMonoBehaviour prefab)
        {
            GameObject obj;
            MonoBehaviourPool pool;
            if (Application.isEditor)
            {
                obj = GameObject.Find(prefab.name + " Pool");
                if (obj != null)
                {
                    pool = obj.GetComponent<MonoBehaviourPool>();
                    if (pool != null)
                    {
                        return pool;
                    }
                }
            }
            obj = new GameObject(prefab.name + " Pool");
            DontDestroyOnLoad(obj);
            pool = obj.AddComponent<MonoBehaviourPool>();
            pool._pooledPrefab = prefab;
            pool._prefabString = prefab.name;
            pool.transform.SetParent(GameObject.FindGameObjectWithTag("Pools").transform);
            return pool;
        }

        /// <summary>
        /// Get an object of the pool's type from the pool, creating one if none remaining
        /// </summary>
        /// <returns>
        /// Pooled object of the pool's type
        /// </returns>
        public PooledMonoBehaviour GetObject()
        {
            PooledMonoBehaviour obj;
            int lastAvailableIndex = _pooledObjects.Count - 1;
            if (lastAvailableIndex >= 0)
            {
                obj = (PooledMonoBehaviour)_pooledObjects[lastAvailableIndex];
                _pooledObjects.RemoveAt(lastAvailableIndex);
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj = Instantiate(_pooledPrefab);
                obj.transform.SetParent(transform, false);
                obj.Pool = this;
            }
            return obj;
        }

        /// <summary>
        /// Add the given object to the pool
        /// </summary>
        /// <param name="obj">
        /// Object to add to the pool
        /// </param>
        public void AddObject(PooledMonoBehaviour obj)
        {
            obj.Initialize();
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform, false);
            obj.name = "Pooled " + _prefabString;
            _pooledObjects.Add(obj);
        }

        /// <summary>
        /// Set the prefab to pool
        /// </summary>
        /// <param name="prefab">
        /// Prefab to pool
        /// </param>
        public void SetPrefab(PooledMonoBehaviour prefab)
        {
            _pooledPrefab = prefab;
        }
    }
}