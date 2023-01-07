using UnityEditor;
using UnityEngine;

namespace Editor.PlayerEnvironment
{
    public class EditorUserSettingTest
    {
        private const string MENU_NAME = "Config/";
        private const string VAL_NAME = "Example";
        
        [MenuItem(MENU_NAME + "Set")]
        private static void SetEditorUserSettings()
        {
            EditorUserSettings.SetConfigValue(VAL_NAME, "value");
            AssetDatabase.SaveAssets();
        }

        [MenuItem(MENU_NAME + "Get")]
        private static void GetEditorUserSettings()
        {
            var value = EditorUserSettings.GetConfigValue(VAL_NAME);
            Debug.Log(value);
        }
    }
}