using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.Utility
{
    /// <summary>
    /// [Unfinished] Allows prefabs to sync there changes back to their prefabs and from their prefabs when nested
    /// inside of other prefabs
    /// </summary>
    public class PrefabSync : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private GameObject _prefabParent;

        private void LoadPrefab()
        {
            _prefabParent = PrefabUtility.GetPrefabParent(_prefab) as GameObject;
        }

        public string GetPrefabPath()
        {
            return AssetDatabase.GetAssetPath(_prefabParent);
        }

        public void ApplyChanges()
        {
            LoadPrefab();
            if (_prefabParent == null)
            {
                Debug.Log("[PrefabSync] Could not find prefab. Aborting");
                return;
            }
            PrefabUtility.ReplacePrefab(gameObject, _prefabParent, ReplacePrefabOptions.ReplaceNameBased);
        }

        public void ConnectPrefab()
        {
            PrefabUtility.ConnectGameObjectToPrefab(gameObject, _prefab);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof (PrefabSync))]
    public class PrefabSyncEditor : UnityEditor.Editor
    {
        private PrefabSync _prefabSync;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            _prefabSync = (PrefabSync) target;

            if (GUILayout.Button("Apply to Prefab"))
            {
                _prefabSync.ApplyChanges();
            }
            if (GUILayout.Button("Connect to Prefab and Update Values"))
            {
                _prefabSync.ConnectPrefab();
            }
        }
    }
#endif
}