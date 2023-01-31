using System;
using System.Linq;
using Runtime.Scripts;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

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
            var root = rootVisualElement;

            var toolbar = new Toolbar();
            root.Add(toolbar);

            var updatedButton = new ToolbarButton() { text = "Update" };
            toolbar.Add(updatedButton);

            // ボタンを押したらCollectObjectsが呼ばれるように
            updatedButton.clicked += CollectObjects;

            // 生成時に一回更新
            CollectObjects();
        }

        private ListView _listView;

        private void CollectObjects()
        {
            var root = rootVisualElement;

            if (_listView != null)
            {
                root.Remove(_listView);
                _listView = null;
            }

            _listView = new ListView();

            var targets = FindObjectsOfType<SimpleObject>().ToList();
            targets.Sort((lhs, rhs) => String.Compare(lhs.name, rhs.name, StringComparison.Ordinal));

            _listView.itemsSource = targets;
            _listView.makeItem = () =>
            {
                var box = new VisualElement();
                box.Add(new Label());
                box.Add(new InspectorElement());
                return box;
            };
            _listView.bindItem = (VisualElement element, int index) =>
            {
                (element.ElementAt(0) as Label).text = targets[index].name;
                (element.ElementAt(1) as InspectorElement).Bind(new SerializedObject(targets[index]));
            };

            _listView.fixedItemHeight = 100;
            root.Add(_listView);
        }
    }
}