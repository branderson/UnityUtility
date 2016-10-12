using System;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// [Thread-safe] Random object which can be safely accessed across multiple threads
    /// </summary>
    public class ThreadSafeRandom : Random
    {
        private object _randomLock;

        public ThreadSafeRandom()
        {
            _randomLock = new object();
        }

        public override int Next()
        {
            lock (_randomLock)
            {
                return base.Next();
            }
        }

        public override int Next(int maxValue)
        {
            lock (_randomLock)
            {
                return base.Next(maxValue);
            }
        }

        public override int Next(int minValue, int maxValue)
        {
            lock (_randomLock)
            {
                return base.Next(minValue, maxValue);
            }
        }

        public override double NextDouble()
        {
            lock (_randomLock)
            {
                return base.NextDouble();
            }
        }

        public override void NextBytes(byte[] buffer)
        {
            lock (_randomLock)
            {
                base.NextBytes(buffer);
            }
        }
    }

    /// <summary>
    /// [Thread-safe] Random number generator for game
    /// </summary>
    public class RNG : Singleton<RNG>
    {
        private ThreadSafeRandom _random;

        public ThreadSafeRandom Random
        {
            get { return _random; }
            set { _random = value; }
        }

        protected RNG() { }

        /// <summary>
        /// Initializes RNG
        /// </summary>
	    public void Initialize()
        {
            Random = new ThreadSafeRandom();
        }
    }
}