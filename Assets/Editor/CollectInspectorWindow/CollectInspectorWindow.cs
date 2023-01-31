using System;
using Runtime.Scripts;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace Editor.CollectInspectorWindow
{
    public class CollectInspectorWindow : EditorWindow
    {
        [MenuItem("Utilities/CollectInspectorWindow")]
        public static void ShowExample()
        {
            CollectInspectorWindow wnd = GetWindow<CollectInspectorWindow>("Collect Inspector Window");
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }
        
        private void CreateGUI()
        {
            var targets = FindObjectsOfType<SimpleObject>();

            var root = rootVisualElement;

            foreach (var target in targets)
            {
                InspectorElement inspector = new InspectorElement(target);
                root.Add(inspector);
            }
        }
    }
}