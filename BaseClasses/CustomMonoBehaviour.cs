using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Utility
{
    
    /// <summary>
    /// MonoBehaviour-derived base class with useful methods for common calculations with vectors and transforms, 
    /// as well as cached version of component access methods
    /// </summary>
    public class CustomMonoBehaviour : MonoBehaviour
    {
        private Transform _transform;
        private readonly Dictionary<Type, List<Component>> _cachedMonoBehaviours = new Dictionary<Type, List<Component>>(); 

        /// <summary>
        /// Caches transform the first time this is called
        /// </summary>
        public new Transform transform
        {
            get
            {
                if (_transform) return _transform;
                _transform = base.transform;
                return transform;
            }
        }

        /// <summary>
        /// Returns the component of Type T if the game object has one attached, null if it doesn't. Attempts to 
        /// find cached component first, otherwise caches all attached components of type T for future use
        /// </summary>
        /// <typeparam name="T">
        /// Type of component to get
        /// </typeparam>
        /// <returns>
        /// Component of type T attached to game object if one exists, null otherwise
        /// </returns>
        public T CachedGetComponent<T>() where T : Component
        {
            List<Component> mb;
            if (_cachedMonoBehaviours.TryGetValue(typeof (T), out mb))
            {
                T component = mb.FirstOrDefault() as T;
                if (component != null) return component;
            }
            List<T> components = base.GetComponents<T>().ToList();
            if (components.Count != 0)
            {
                _cachedMonoBehaviours[typeof (T)] = components as List<Component>;
            }
            return components[0];
        }

        /// <summary>
        /// Returns all components of Type type in the GameObject. Attempts to find cached components first, otherwise
        /// caches the results for future use
        /// </summary>
        /// <typeparam name="T">
        /// Type of component to get
        /// </typeparam>
        /// <returns>
        /// Component of type T attached to game object if one exists, null otherwise
        /// </returns>
        public T[] CachedGetComponents<T>() where T : Component
        {
            List<Component> mb;
            if (_cachedMonoBehaviours.TryGetValue(typeof (T), out mb))
            {
                return mb.ToArray() as T[];
            }
            T[] mbArr = base.GetComponents<T>();
            if (mbArr != null)
            {
                _cachedMonoBehaviours[typeof (T)] = mbArr.ToList() as List<Component>;
            }
            return mbArr;
        }

        /// <summary>
        /// Adds a component of type T to the game object, caching the result. Will not cache additional component 
        /// added as a sideffect. 
        /// </summary>
        /// <typeparam name="T">
        /// Type of component to add
        /// </typeparam>
        /// <returns>
        /// Component added to game object
        /// </returns>
        public T CachedAddComponent<T>() where T : Component
        {
            T component = gameObject.AddComponent<T>();
            List<Component> mb;
            if (_cachedMonoBehaviours.TryGetValue(typeof (T), out mb))
            {
                mb.Add(component);
                return component;
            }
            _cachedMonoBehaviours[typeof(T)] = new List<Component>() {component};
            return component;
        }

        /// <summary>
        /// Calculate the distance between the object and a position
        /// </summary>
        /// <param name="other">
        /// Position to calculate object's distance from
        /// </param>
        /// <returns>
        /// Distance from object to other
        /// </returns>
        public float SquaredDistance(Vector2 other)
        {
            return Mathf.Pow(transform.position.x - other.x, 2) + 
                Mathf.Pow(transform.position.y - other.y, 2);
        }

        /// <summary>
        /// Calculate the distance between the object and a position
        /// </summary>
        /// <param name="other">
        /// Position to calculate object's distance from
        /// </param>
        /// <returns>
        /// Distance from object to other
        /// </returns>
        public float SquaredDistance(Vector3 other)
        {
            
            return Mathf.Pow(transform.position.x - other.x, 2) + 
                Mathf.Pow(transform.position.y - other.y, 2) +
                Mathf.Pow(transform.position.z - other.z, 2);
        }

        public float SquaredDistance2(Vector2 other)
        {
            return SquaredDistance(other);
        }

        public float SquaredDistance3(Vector3 other)
        {
            return SquaredDistance(other);
        }

        /// <summary>
        /// Calculate the Manhattan distance from the object to a position
        /// </summary>
        /// <param name="other">
        /// Position to calculate object's Manhattan distance to
        /// </param>
        /// <returns>
        /// Manhattan distance from object to other
        /// </returns>
        public Vector2 ManhattanDistance(Vector2 other)
        {
            return new Vector2(other.x - transform.position.x,
                other.y - transform.position.y);
        }

        /// <summary>
        /// Calculate the Manhattan distance from the object to a position
        /// </summary>
        /// <param name="other">
        /// Position to calculate object's Manhattan distance to
        /// </param>
        /// <returns>
        /// Manhattan distance from object to other
        /// </returns>
        public Vector3 ManhattanDistance(Vector3 other)
        {
            return new Vector3(other.x - transform.position.x,
                other.y - transform.position.y,
                other.z - transform.position.z);
        }

        public Vector2 ManhattanDistance2(Vector2 other)
        {
            return ManhattanDistance(other);
        }

        public Vector3 ManhattanDistance3(Vector3 other)
        {
            return ManhattanDistance(other);
        }

        /// <summary>
        /// Calculate the direction from the object to a position as a unit vector
        /// </summary>
        /// <param name="other">
        /// Position to calculate direction from object
        /// </param>
        /// <returns>
        /// Direction from object to position as a unit vector
        /// </returns>
        public Vector2 Direction(Vector2 other)
        {
            return ManhattanDistance(other).normalized;
        }

        /// <summary>
        /// Calculate the direction from the object to a position as a unit vector
        /// </summary>
        /// <param name="other">
        /// Position to calculate direction from object
        /// </param>
        /// <returns>
        /// Direction from object to position as a unit vector
        /// </returns>
        public Vector3 Direction(Vector3 other)
        {
            return ManhattanDistance(other).normalized;
        }

        public Vector2 Direction2(Vector2 other)
        {
            return Direction(other);
        }

        public Vector3 Direction3(Vector2 other)
        {
            return Direction(other);
        }
    }
}