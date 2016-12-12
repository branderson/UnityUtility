using UnityEngine;

namespace Assets.Utility.Behaviours
{
    /// <summary>
    /// Destroy other objects in the scene with the same tag on Awake
    /// </summary>
    public class DestroyOthersWithTag : MonoBehaviour
    {
        public void Awake()
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(gameObject.tag))
            {
                if (obj != gameObject)
                {
                    Destroy(obj);
                }
            }
        }
    }
}