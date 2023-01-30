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

        private void CreateGUI()
        {
            var targetComponent = GameObject.FindObjectOfType<SimpleObject>();

            var root = rootVisualElement;

            InspectorElement inspector = new InspectorElement(targetComponent);
            
            root.Add(inspector);
        }
    }
}