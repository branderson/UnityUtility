namespace Assets.Scripts.Utility.Pooling
{
    public interface IPoolable
    {
        /// <summary>
        /// Set all fields to initial values
        /// </summary>
        void Initialize();

        /// <summary>
        /// Clear the object's state and return it to the pool
        /// </summary>
        void ReturnToPool();

        /// <summary>
        /// Get a pooled instance of this type
        /// </summary>
        /// <typeparam name="T">
        /// Type to get an instance of
        /// </typeparam>
        /// <returns>
        /// Pooled instance of given type
        /// </returns>
        T GetPooledInstance<T>() where T : PooledMonoBehaviour;
    }
}