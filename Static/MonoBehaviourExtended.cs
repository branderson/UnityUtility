using UnityEngine;

namespace Assets.Utility.Static
{
    public enum Axis
    {
        X,
        Y,
        Z
    };

    static public class MethodExtensionForMonoBehaviourTransform {
        /// <summary>
        /// Gets or adds a component. 
        /// Usage example:
        /// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
        /// </summary>
        static public T GetOrAddComponent<T> (this Component child) where T: Component {
            T result = child.GetComponent<T>();
            if (result == null) {
                result = child.gameObject.AddComponent<T>();
            }
            return result;
        }

        /// <summary>
        /// Gets or adds a component, checking for a cached reference first, and caching the result if not found.
        /// Usage example:
        /// BoxCollider boxCollider = transform.CachedGetOrAddComponent<BoxCollider>();
        /// </summary>
        static public T CachedGetOrAddComponent<T> (this CustomMonoBehaviour child) where T: Component {
            T result = child.CachedGetComponent<T>();
            if (result == null) {
                result = child.CachedAddComponent<T>();
            }
            return result;
        }

        static public void AdjustPosition(this Transform transform, float x, float y)
        {
            transform.position = new Vector3(transform.position.x + x, 
                transform.position.y + y, 
                transform.position.z);
        }

        static public void AdjustPosition(this Transform transform, float x, float y, float z)
        {
            transform.position = new Vector3(transform.position.x + x, 
                transform.position.y + y, 
                transform.position.z + z);
        }

        static public void AdjustPosition(this Transform transform, Vector2 amount)
        {
            transform.position = new Vector3(transform.position.x + amount.x, 
                transform.position.y + amount.y, 
                transform.position.z);
        }

        static public void AdjustPosition(this Transform transform, Vector3 amount)
        {
            transform.position = new Vector3(transform.position.x + amount.x, 
                transform.position.y + amount.y, 
                transform.position.z + amount.z);
        }

        static public void AdjustLocalPosition(this Transform transform, float x, float y)
        {
            transform.localPosition = new Vector3(transform.position.x + x, 
                transform.position.y + y, 
                transform.position.z);
        }

        static public void AdjustLocalPosition(this Transform transform, float x, float y, float z)
        {
            transform.localPosition = new Vector3(transform.position.x + x, 
                transform.position.y + y, 
                transform.position.z + z);
        }

        static public void AdjustLocalPosition(this Transform transform, Vector2 amount)
        {
            transform.localPosition = new Vector3(transform.position.x + amount.x, 
                transform.position.y + amount.y, 
                transform.position.z);
        }

        static public void AdjustLocalPosition(this Transform transform, Vector3 amount)
        {
            transform.localPosition = new Vector3(transform.position.x + amount.x, 
                transform.position.y + amount.y, 
                transform.position.z + amount.z);
        }

        static public void SetPosition2D(this Transform transform, float x, float y)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }

        static public void SetPosition2D(this Transform transform, Vector2 pos)
        {
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }

        static public void SetPosition3D(this Transform transform, float x, float y, float z)
        {
            transform.position = new Vector3(x, y, z);
        }

        static public void SetAxisPosition(this Transform transform, Axis axis, float value)
        {
            switch (axis)
            {
                case Axis.X:
                    transform.position = new Vector3(value, transform.position.y, transform.position.z);
                    break;
                case Axis.Y:
                    transform.position = new Vector3(transform.position.x, value, transform.position.z);
                    break;
                case Axis.Z:
                    transform.position = new Vector3(transform.position.x, transform.position.y, value);
                    break;
                default:
                    break;
            }
        }
    }
}