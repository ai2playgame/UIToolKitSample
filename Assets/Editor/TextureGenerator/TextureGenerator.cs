using UnityEditor;
using UnityEngine.UIElements;

namespace Editor.TextureGenerator
{
    public class TextureGenerator : EditorWindow
    {
        [MenuItem("Utilities/TextureGenerator")]
        public static void ShowExample()
        {
            GetWindow<TextureGenerator>("Texture Generator");
        }

        private void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            var imageRedElement = new Image();
            root.Add(imageRedElement);
            
            root.Add(new Label("sample"));
        }
    }
}