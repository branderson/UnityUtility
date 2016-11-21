using System.Reflection;
using UnityEditor;

namespace Assets.Utility
{
    public class SkinSwitcher
    {
        [MenuItem("Assets/Switch Skin")]
        [MenuItem("Edit/Switch Skin")]
        public static void SwitchSkin()
        {
            MethodInfo method = typeof(EditorGUIUtility).GetMethod("Internal_SwitchSkin", BindingFlags.Static | BindingFlags.NonPublic);
            method.Invoke(typeof(EditorGUIUtility), new object[] {});
        }
    }
}
