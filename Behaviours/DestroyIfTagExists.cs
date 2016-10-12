using UnityEngine;

namespace Assets.Utility.Behaviours
{
    /// <summary>
    /// Destroy the object if object with its tag already exists in scene
    /// </summary>
    public class DestroyIfTagExists : MonoBehaviour
    {
        public void Start()
        {
            if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
            {
                Destroy(gameObject);
            }
        }
    }
}