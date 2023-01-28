using UnityEditor;
using UnityEngine.UIElements;

namespace Editor.Manual.Examples.CreateListAndTreeViews
{
    public class PlanetsMultiColumnTreeView : PlanetsWindow
    {
        [MenuItem("UI Toolkit/Docs/Examples/002-PlanetsMultiColumnTreeView")]
        private static void Summon()
        {
            GetWindow<PlanetsMultiColumnTreeView>("MultiColumn Planet Tree");
        }

        private void CreateGUI()
        {
            uxml.CloneTree(rootVisualElement);
            var treeView = rootVisualElement.Q<MultiColumnTreeView>();

            treeView.SetRootItems(TreeRoots);

            treeView.columns["name"].makeCell = () => new Label();
            treeView.columns["name"].bindCell = (element, index) =>
                (element as Label).text = treeView.GetItemDataForIndex<IPlanetOrGroup>(index).Name;

            treeView.columns["populated"].makeCell = () => new Toggle();
            treeView.columns["populated"].bindCell = (element, index) =>
                (element as Toggle).value = treeView.GetItemDataForIndex<IPlanetOrGroup>(index).Populated;
        }
    }
}