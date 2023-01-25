using System;
using UnityEditor;
using UnityEngine.UIElements;

namespace Editor.LIGHT11Tutorial
{
    public class LIGHT11Tutorial : EditorWindow
    {
        [MenuItem("LIGHT11/Example")]
        public static void ShowWindow()
        {
            GetWindow<LIGHT11Tutorial>("Example");
        }

        private void OnEnable()
        {
            var root = rootVisualElement;
            var box = new Box();
            box.Add(new Button()
            {
                text = "Example Button"
            });
            box.Add(new Label()
            {
                text = "Example Button"
            });

            root.Add(box);
        }
    }
}