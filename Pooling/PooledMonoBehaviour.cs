using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utility.Pooling
{
    /// <summary>
    /// MonoBehaviour that can be pooled
    /// 
    /// Get an instance of a pooled MonoBehaviour like this:
    /// Foo bar = fooPrefab.GetPooledInstance<Foo>();
    ///
    /// Must have an empty GameObject tagged "Pools" in your scene to call this
    /// </summary>
    public abstract class PooledMonoBehaviour : CustomMonoBehaviour, IPoolable
    {
        [System.NonSerialized]
        public MonoBehaviourPool Pool;

        public void Start()
        {
            SceneManager.sceneLoaded += LevelWasLoaded;
        }

        public void OnDestroy()
        {
            SceneManager.sceneLoaded -= LevelWasLoaded;
        }

        /// <summary>
        /// Set all fields to initial values
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Clear the object's state and return it to the pool
        /// </summary>
        public void ReturnToPool()
        {
            if (Pool != null)
            {
                Pool.AddObject(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Get a pooled instance of this type
        /// </summary>
        /// <typeparam name="T">
        /// Type to get an instance of
        /// </typeparam>
        /// <returns>
        /// Pooled instance of given type
        /// </returns>
        public T GetPooledInstance<T>() where T : PooledMonoBehaviour
        {
            if (Pool == null)
            {
                Pool = MonoBehaviourPool.GetPool(this);
            }
            return (T) Pool.GetObject();
        }

        private void LevelWasLoaded(Scene scene, LoadSceneMode mode)
        {
            ReturnToPool();
        }
    }
}