using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.ManualCustomEditor
{
    public class ManualCustomEditor : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;
        [SerializeField] private VisualTreeAsset m_UXMLTree = default;

        [MenuItem("CustomEditor/Manual")]
        public static void ShowExample()
        {
            ManualCustomEditor wnd = GetWindow<ManualCustomEditor>();
            wnd.titleContent = new GUIContent("ManualCustomEditor");
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            // Instantiate UXML
            root.Add(m_VisualTreeAsset.Instantiate());
            root.Add(m_UXMLTree.Instantiate());
            
            // C#コードからUIコントロールを加える
            Label label = new Label("These controls were created using C# code.");
            root.Add(label);

            Button button = new Button();
            button.name = "button3";
            button.text = "this is button3";
            root.Add(button);

            Toggle toggle = new Toggle();
            toggle.name = "toggle3";
            toggle.label = "Number?";
            root.Add(toggle);
        }
    }
}
