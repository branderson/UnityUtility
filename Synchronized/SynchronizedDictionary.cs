using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Utility.Synchronized
{
    /// <summary>
    /// [Thread-safe] Thread-safe dictionary
    /// </summary>
    /// <typeparam name="TKey">
    /// Key to store in dictionary
    /// </typeparam>
    /// <typeparam name="TValue">
    /// Comparable value for data members
    /// </typeparam>
    [Serializable]
    public class SynchronizedDictionary <TKey, TValue> : IDictionary<TKey, TValue>
    {
        public int _count;
        public bool _isReadOnly;

        public ICollection<TKey> _keys;
        public ICollection<TValue> _values;

        private Dictionary<TKey, TValue> _data;
        private readonly object _root;
        public readonly object SyncRoot;

        public SynchronizedDictionary()
        {
            _data = new Dictionary<TKey, TValue>();
            _root = new object();
            SyncRoot = _root;
        }

        public int Count
        {
            get { lock (_root) { return _data.Count;} }
            private set { lock (_root) { _count = value;} }
        }

        public bool IsReadOnly
        {
            get { lock (_root) { return _isReadOnly;} }
            set { lock (_root) _isReadOnly = value; }
        }

        public ICollection<TKey> Keys
        {
            get { lock (_root) { return _data.Keys;} }
        }

        public ICollection<TValue> Values
        {
            get { lock (_root) { return _data.Values;} }
        }

        public void Add(TKey key, TValue value)
        {
            lock (_root)
            {
                _data.Add(key, value);
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            lock (_root)
            {
                _data.Add(item.Key, item.Value);
            }
        }

        public void Clear()
        {
            lock (_root)
            {
                _data.Clear();
            }
        }

        public bool ContainsKey(TKey key)
        {
            lock (_root)
            {
                return _data.ContainsKey(key);
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            lock (_root)
            {
                return _data.ContainsKey(item.Key) && _data[item.Key].Equals(item.Value);
            }
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            lock (_root)
            {
                int i = arrayIndex;
                foreach (KeyValuePair<TKey, TValue> item in _data)
                {
                    array[i] = item;
                    i++;
                }
            }
        }

        public bool Remove(TKey key)
        {
            lock (_root)
            {
                return _data.Remove(key);
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            lock (_root)
            {
                return _data.Remove(item.Key);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            lock (_root)
            {
                return _data.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (_root)
            {
                return GetEnumerator();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            lock (_root)
            {
                return _data.TryGetValue(key, out value);
            }
        }

        public TValue this[TKey key]
        {
            get { lock (_root) { return _data[key];} }
            set { lock (_root) { _data[key] = value;} }
        }
    }
}