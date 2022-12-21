using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.EasyBatchRename
{
    public class DragAndDropEditor : EditorWindow
    {
        private List<GameObject> targetObjects;
        private List<string> targetObjectNames;

        [MenuItem("Utilities/DragAndDrop")]
        public static void ShowExample()
        {
            DragAndDropEditor window = GetWindow<DragAndDropEditor>();
            window.titleContent = new GUIContent("drag and drop");
        }

        public void OnEnable()
        {
            var root = rootVisualElement;

            TwoPaneSplitView t0 = new TwoPaneSplitView(0, 30, TwoPaneSplitViewOrientation.Horizontal);
            root.Add(t0);
            
            var dropArea = new VisualElement();
            dropArea.Add(new Label {text = "Drag and drop GameObjects."});
            dropArea.RegisterCallback<DragPerformEvent>(OnDragPerformEvent);
            dropArea.RegisterCallback<DragUpdatedEvent>(evt =>
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            });
            t0.Add(dropArea);

            var label2 = new VisualElement();
            label2.Add(new Label { text = "aiueo"});
            t0.Add(label2);

            var clearButton = new Button
            {
                text = "clear"
            };
            clearButton.RegisterCallback<ClickEvent>(evt =>
                {
                    targetObjects.Clear();
                    targetObjectNames.Clear();
                }
            );
            root.Add(clearButton);
        }

        private void OnDragPerformEvent(DragPerformEvent evt)
        {
            DragAndDrop.AcceptDrag();

            var inHierarchyObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject))
                .Select(c => c as GameObject)
                .Where(c =>
                    !EditorUtility.IsPersistent(c.transform.root.gameObject) &&
                    !(c.hideFlags == HideFlags.NotEditable || c.hideFlags == HideFlags.HideAndDontSave)
                );
            
            foreach (var draggedObj in DragAndDrop.objectReferences)
            {
                var gameObject = draggedObj as GameObject;
                if (gameObject == null)
                    continue;
                if (inHierarchyObjects.Contains(gameObject) && !targetObjects.Contains(gameObject))
                {
                    targetObjects.Add(gameObject);
                    targetObjectNames.Add(gameObject.name);
                }
            }
            Debug.Log(string.Join(", ", targetObjectNames));
        }
    }
}