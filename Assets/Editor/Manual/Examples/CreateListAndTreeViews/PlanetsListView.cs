using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.Manual.Examples.CreateListAndTreeViews
{
    public class PlanetsListView : PlanetsWindow
    {
        [MenuItem("UI Toolkit/Docs/Examples/002-PlanetsListView")]
        public static void ShowExample()
        {
            PlanetsListView wnd = GetWindow<PlanetsListView>();
            wnd.titleContent = new GUIContent("PlanetsListView");
        }

        public void CreateGUI()
        {
            uxml.CloneTree(rootVisualElement);
            var listView = rootVisualElement.Q<ListView>();

            listView.itemsSource = Planets;

            listView.makeItem = () => new Label();
            listView.bindItem = (VisualElement element, int index) =>
                (element as Label).text = Planets[index].Name;
        }
    }
}
