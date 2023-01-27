using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.Manual.Examples.RelativeAndAbsolutePositioning
{
    public class PositioningTestWindow : EditorWindow
    {
        [MenuItem("UI Toolkit/Docs/Examples/PositioningTestWindow")]
        public static void ShowExample()
        {
            var wnd = GetWindow<PositioningTestWindow>();
            wnd.titleContent = new GUIContent("Positioning Test Window");
        }

        public void CreateGUI()
        {
            for (int i = 0; i < 2; ++i)
            {
                var tmp = new VisualElement();
                tmp.style.width = 70;
                tmp.style.height = 70;
                tmp.style.marginBottom = 2;
                tmp.style.backgroundColor = Color.gray;
                rootVisualElement.Add(tmp);
            }

            // Relative positioning
            var relative = new Label("Relative\nPos\n25, 0");
            relative.style.width = 70;
            relative.style.height = 70;
            relative.style.left = 25;
            relative.style.marginBottom = 2;
            relative.style.backgroundColor = Color.magenta;
            rootVisualElement.Add(relative);

            for (int i = 0; i < 2; i++)
            {
                var temp = new VisualElement();
                temp.style.width = 70;
                temp.style.height = 70;
                temp.style.marginBottom = 2;
                temp.style.backgroundColor = Color.gray;
                rootVisualElement.Add(temp);
            }

            // Absolute positioning
            var absolutePositionElement = new Label("Absolute\nPos\n25, 25");
            absolutePositionElement.style.position = Position.Absolute;
            absolutePositionElement.style.top = 25;
            absolutePositionElement.style.left = 25;
            absolutePositionElement.style.width = 70;
            absolutePositionElement.style.height = 70;
            absolutePositionElement.style.backgroundColor = Color.black;
            rootVisualElement.Add(absolutePositionElement);
        }
    }
}