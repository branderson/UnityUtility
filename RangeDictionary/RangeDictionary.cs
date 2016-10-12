using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Utility.Tuple;

namespace Assets.Scripts.Utility.RangeDictionary
{
    /// <summary>
    /// Defines a range
    /// </summary>
    public class Range <T> where T : IComparable
    {
        private Tuple<T, T> _bounds;

        public Range(T min, T max)
        {
            _bounds = new Tuple<T, T>(min, max);
        }

        public T Max
        {
            get { return _bounds.Item2; }
            set { _bounds = new Tuple<T, T>(_bounds.Item1, value); }
        }

        public T Min
        {
            get { return _bounds.Item1; }
            set { _bounds = new Tuple<T, T>(value, _bounds.Item2); }
        }

        /// <summary>
        /// Checks if a value is within the range inclusive
        /// </summary>
        public bool Contains(T value)
        {
            return value.CompareTo(Max) <= 0 && value.CompareTo(Min) >= 0;
        }

        /// <summary>
        /// Checks if a value is within the range exclusive
        /// </summary>
        public bool ContainsExclusive(T value)
        {
            return value.CompareTo(Max) < 0 && value.CompareTo(Min) > 0;
        }

        /// <summary>
        /// Checks if a value is within the range inclusive on the bottom and exclusive on the top
        /// </summary>
        public bool ContainsExclusiveTop(T value)
        {
            return value.CompareTo(Max) < 0 && value.CompareTo(Min) >= 0;
        }
    }

    /// <summary>
    /// Dictionary allowing getting all values whose keys are between a maximum and a minimum value
    /// </summary>
    /// <typeparam name="TKey">
    /// Key to store in dictionary
    /// </typeparam>
    /// <typeparam name="TValue">
    /// Comparable value for data members
    /// </typeparam>
    public class RangeDictionary <TKey, TValue> : IDictionary<TKey, TValue> where TValue : IComparable
    {
        public int _count;
        public bool _isReadOnly;

        public ICollection<TKey> _keys;
        public ICollection<TValue> _values;

        private Dictionary<TKey, TValue> _data; 

        public RangeDictionary()
        {
            _data = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Get a list of all values whose keys are within the given range inclusive
        /// </summary>
        /// <param name="range">
        /// Range to get values within
        /// </param>
        /// <returns>
        /// List of values within given range inclusive
        /// </returns>
        public List<TKey> GetInRange(Range<TValue> range)
        {
            return (from item in _data where range.Contains(item.Value) select item.Key).ToList();
        }

        /// <summary>
        /// Get a list of all values whose keys are within the given range exclusive
        /// </summary>
        /// <param name="range">
        /// Range to get values within
        /// </param>
        /// <returns>
        /// List of values within given range exclusive
        /// </returns>
        public List<TKey> GetInRangeExclusive(Range<TValue> range)
        {
            return (from item in _data where range.ContainsExclusive(item.Value) select item.Key).ToList();
        }
        
        /// <summary>
        /// Get a list of all values whose keys are within the given range inclusive on the bottom and 
        /// exclusive on the top
        /// </summary>
        /// <param name="range">
        /// Range to get values within
        /// </param>
        /// <returns>
        /// List of values within given range inclusive on the bottom and exclusive on the top
        /// </returns>
        public List<TKey> GetInRangeExclusiveTop(Range<TValue> range)
        {
            return (from item in _data where range.ContainsExclusiveTop(item.Value) select item.Key).ToList();
        }

        /// <summary>
        /// Gets the largest value stored in the dictionary
        /// </summary>
        /// <returns>
        /// Largest value stored in the dictionary
        /// </returns>
        public TValue GetMaxValue()
        {
            return _data.Max(item => item.Value);
        }

        /// <summary>
        /// Gets the smallest value stored in the dictionary
        /// </summary>
        /// <returns>
        /// Smallest value stored in the dictionary
        /// </returns>
        public TValue GetMinValue()
        {
            return _data.Min(item => item.Value);
        }

        public int Count
        {
            get { return _data.Count; }
            private set { _count = value; }
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { _isReadOnly = value; }
        }

        public ICollection<TKey> Keys
        {
            get { return _data.Keys; }
        }

        public ICollection<TValue> Values
        {
            get { return _data.Values; }
        }

        public void Add(TKey key, TValue value)
        {
            _data.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _data.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool ContainsKey(TKey key)
        {
            return _data.ContainsKey(key);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _data.ContainsKey(item.Key) && _data[item.Key].Equals(item.Value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (KeyValuePair<TKey, TValue> item in _data)
            {
                array[i] = item;
                i++;
            }
        }

        public bool Remove(TKey key)
        {
            return _data.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _data.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _data.TryGetValue(key, out value);
        }

        public TValue this[TKey key]
        {
            get { return _data[key]; }
            set { _data[key] = value; }
        }
    }
}