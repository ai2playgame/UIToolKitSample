using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.ManualCustomEditor
{
    public class ManualCustomEditor : EditorWindow
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        [MenuItem("Window/UI Toolkit/ManualCustomEditor")]
        public static void ShowExample()
        {
            ManualCustomEditor wnd = GetWindow<ManualCustomEditor>();
            wnd.titleContent = new GUIContent("ManualCustomEditor");
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            // VisualElement label = new Label("Hello World! From C#");
            // root.Add(label);

            // Instantiate UXML
            VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
            root.Add(labelFromUXML);
        }
    }
}
