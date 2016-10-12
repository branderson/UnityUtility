using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// [Unfinished] Maintains changes to spawned prefabs, while automatically updating the object to 
    /// prefab when prefab is updated. Include this on all prefabs
    /// </summary>
    public class PrefabHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        public void Awake()
        {
            GameObject spawned = Instantiate(_prefab);
            spawned.transform.parent = transform.parent;
        }
    }
}