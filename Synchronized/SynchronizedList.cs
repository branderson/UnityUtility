using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Utility.Synchronized
{
    [Serializable]
    public class SynchronizedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
    {
        private List<T> _list;
        private readonly object _root;
        public readonly object SyncRoot;

        public SynchronizedList()
        {
            _list = new List<T>();
            _root = ((ICollection) _list).SyncRoot;
            SyncRoot = _root;
        }

        public SynchronizedList(List<T> list)
        {
            _list = new List<T>(list);
            _root = ((ICollection) _list).SyncRoot;
            SyncRoot = _root;
        }

        public SynchronizedList(SynchronizedList<T> list)
        {
            lock (list.SyncRoot)
            {
                _list = new List<T>(list._list);
            }
            _root = ((ICollection) _list).SyncRoot;
            SyncRoot = _root;
        }

        /// <summary>
        /// [Thread-safe] Get a shallow copy of the underlying list
        /// </summary>
        /// <returns>
        /// Shallow copy of underlying list
        /// </returns>
        public List<T> GetList()
        {
            lock (_root)
            {
                return new List<T>(_list);
            }
        } 

        public IEnumerator<T> GetEnumerator()
        {
            lock (_root)
            {
                return _list.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            lock (_root)
            {
                _list.Add(item);
            }
        }

        public void Clear()
        {
            lock (_root)
            {
                _list.Clear();
            }
        }

        public bool Contains(T item)
        {
            lock (_root)
            {
                return _list.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (_root)
            {
                _list.CopyTo(array, arrayIndex);
            }
        }

        public bool Remove(T item)
        {
            lock (_root)
            {
                return _list.Remove(item);
            }
        }

        public int Count
        {
            get { lock (_root) { return _list.Count;} }
        }

        public bool IsReadOnly
        {
            get { lock (_root) { return false;} }
        }

        public int IndexOf(T item)
        {
            lock (_root)
            {
                return _list.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            lock (_root)
            {
                _list.Insert(index, item);
            }
        }

        public void RemoveAt(int index)
        {
            lock (_root)
            {
                _list.RemoveAt(index);
            }
        }

        public T this[int index]
        {
            get { lock (_root) { return _list[index]; } }
            set { lock (_root) { _list[index] = value; } }
        }

        public T Find(Predicate<T> match)
        {
            lock (_root)
            {
                return _list.Find(match);
            }
        }
    }
}