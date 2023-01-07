using UnityEditor;
using UnityEngine;

namespace Editor.PlayerEnvironment
{
    // EditorUserSettingsは、UserSettings以下に記録される。
    // 今登録しているKeyをまとめて取得する方法はおそらくないので、
    // 自前で作って、Library以下にJSONを保存するような仕組みを作ったほうがよさそう
    public static class EditorUserSettingTest
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