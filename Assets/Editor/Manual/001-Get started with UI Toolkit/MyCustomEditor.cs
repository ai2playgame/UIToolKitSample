using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;
    
    [SerializeField]
    private VisualTreeAsset m_UXMLTree = default;

    [MenuItem("UI Toolkit/Docs/001 Get started with UI Toolkit")]
    public static void ShowExample()
    {
        MyCustomEditor wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("MyCustomEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
        
        root.Add(m_UXMLTree.Instantiate());
        
        // C#側からコントロールを追加する
        Label label = new Label("These controls were created using C# code.");
        root.Add(label);

        Button button = new Button()
        {
            name = "button3",
            text = "This is button3."
        };
        Toggle toggle = new Toggle()
        {
            name = "toggle3",
            label = "Number?"
        };
        root.Add(button);
        root.Add(toggle);
        
        // event handlerを設定する
        SetupButtonHandler();
    }

    private void SetupButtonHandler()
    {
        VisualElement root = rootVisualElement;
        var buttons = root.Query<Button>();
        buttons.ForEach(RegisterHandler);
    }

    private void RegisterHandler(Button button)
    {
        button.RegisterCallback<ClickEvent>(PrintClickMessage);
    }

    private int m_ClickCount = 0;
    private const string m_ButtonPrefix = "button";
    private void PrintClickMessage(ClickEvent evt)
    {
        VisualElement root = rootVisualElement;

        ++m_ClickCount;

        Button button = evt.currentTarget as Button;
        string buttonNumber = button.name.Substring(m_ButtonPrefix.Length);
        string toggleName = "toggle" + buttonNumber;
        Toggle toggle = root.Q<Toggle>(toggleName);

        Debug.Log($"Button was clicked! " + (toggle.value ? " Count: " + m_ClickCount : "xxx"));
    }
}