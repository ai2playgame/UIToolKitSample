using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.Manual.Examples.CreateListAndTreeViews
{
    public class PlanetsMultiColumnListView : PlanetsWindow
    {
        [MenuItem("UI Toolkit/Docs/Examples/002-PlanetsMultiColumnListView")]
        public static void ShowExample()
        {
            var wnd = GetWindow<PlanetsMultiColumnListView>();
            wnd.titleContent = new GUIContent("PlanetsMultiColumListView");
        }

        private void CreateGUI()
        {
            // uxml.CloneTree(rootVisualElement);
            rootVisualElement.Add(uxml.Instantiate());
            var listView = rootVisualElement.Q<MultiColumnListView>();

            listView.itemsSource = Planets;

            listView.columns["name"].makeCell = () => new Label();
            listView.columns["name"].bindCell = (element, index) =>
                (element as Label).text = Planets[index].Name;
            
            listView.columns["populated"].makeCell = () => new Toggle();
            listView.columns["populated"].bindCell = (element, index) =>
                (element as Toggle).value = Planets[index].Populated;
        }
    }
}