using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class CustomMonoBehaviour : MonoBehaviour
    {
        private Transform _transform;

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