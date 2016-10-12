using UnityEngine;

namespace Assets.Scripts.Utility
{
    public enum Axis
    {
        X,
        Y,
        Z
    };

    static public class MethodExtensionForMonoBehaviourTransform {
        /// <summary>
        /// Gets or add a component. Usage example:
        /// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
        /// </summary>
        static public T GetOrAddComponent<T> (this Component child) where T: Component {
            T result = child.GetComponent<T>();
            if (result == null) {
                result = child.gameObject.AddComponent<T>();
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