using System.Globalization;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Assets.Utility
{
    public class SkinSwitcher
    {
        [MenuItem("Assets/Switch Skin")]
        [MenuItem("Edit/Switch Skin")]
        public static void SwitchSkin()
        {
            MethodInfo switchSkin = typeof(EditorGUIUtility).GetMethod("Internal_SwitchSkin", BindingFlags.Static | BindingFlags.NonPublic);
            switchSkin.Invoke(typeof(EditorGUIUtility), BindingFlags.Static | BindingFlags.NonPublic, null, new object[] {}, CultureInfo.CurrentCulture);
        }
    }
}
