using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.EasyBatchRename
{
    public class EasyBatchRenamer : EditorWindow
    {
        [MenuItem("Utilities/EasyBatchRenamer")]
        public static void ShowExample()
        {
            EasyBatchRenamer wnd = GetWindow<EasyBatchRenamer>();
            wnd.titleContent = new GUIContent("Easy Batch Renamer");
        }

        public void CreateGUI()
        {
            // 選択中のGameObjectの名前を取得する
            GameObject[] selectedObjects = Selection.gameObjects;
            var selectedObjNames = new List<string>();
            foreach (var obj in selectedObjects)
            {
                selectedObjNames.Add(obj.name);
            }
            
            // 新しい名前を決める
            var newObjectNames = new List<string>(selectedObjNames);
            for (int i = 0; i < newObjectNames.Count; ++i)
            {
                newObjectNames[i] = $"{newObjectNames[i]} {i}";
            }
            
            // ラベル追加
            var label1 = new Label();
            label1.text = "BEFORE";
            rootVisualElement.Add(label1);

            // 選択しているの元の名前を表示するListView
            Func<VisualElement> makeItem = () => new Label();
            Action<VisualElement, int> bindOriginalName = (e, i) => (e as Label).text = selectedObjNames[i];
            var originalNameListView = new ListView(selectedObjNames, 16, makeItem, bindOriginalName);
            // listView.selectionType = SelectionType.Multiple;
            // listView.itemsChosen += obj => Debug.Log($"onItemsChosen: {obj}");
            // listView.selectionChanged += objs => Debug.Log($"onSelectionChanged: {objs}");
            originalNameListView.style.flexGrow = 1.0f;

            rootVisualElement.Add(originalNameListView);
            
            // ラベル追加
            var label2 = new Label();
            label2.text = "AFTER";
            rootVisualElement.Add(label2);
            
            // 名前変更後のPreview ListView
            Action<VisualElement, int> bindNewName = (e, i) => (e as Label).text = newObjectNames[i];
            var newNameListView = new ListView(newObjectNames, 16, makeItem, bindNewName);
            newNameListView.style.flexGrow = 1.0f;
            rootVisualElement.Add(newNameListView);

            // ボタンを押したら名前変更確定
            var button = new Button
            {
                text = "名前変更を確定する"
            };
            button.RegisterCallback<ClickEvent>(evt =>
            {
                var selectedObjs = Selection.objects;
                Undo.RecordObjects(selectedObjs, "rename");
                for (int i = 0; i < selectedObjs.Length; ++i)
                {
                    Debug.Log($"{selectedObjs[i].name} -> {newObjectNames[i]}");
                    selectedObjs[i].name = newObjectNames[i];
                }
                // Undo.RecordObjects(selectedObjs, "rename");
            });
            rootVisualElement.Add(button);

        }
    }
}
