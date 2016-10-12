namespace Assets.Scripts.Utility.Pooling
{
    public interface IPool
    {
        IPool GetPool(IPoolable prefab);

        /// <summary>
        /// Get an object of the pool's type from the pool, creating one if none remaining
        /// </summary>
        /// <returns>
        /// Pooled object of the pool's type
        /// </returns>
        IPoolable GetObject();

        /// <summary>
        /// Add the given object to the pool
        /// </summary>
        /// <param name="obj">
        /// Object to add to the pool
        /// </param>
        void AddObject(IPoolable obj);
    }
}