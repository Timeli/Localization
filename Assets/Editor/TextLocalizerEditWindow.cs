using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class TextLocalizerEditWindow : EditorWindow
{
    public static void Open(string key)
    {
        TextLocalizerEditWindow window = new TextLocalizerEditWindow(); 
        window.titleContent = new GUIContent("Localizer Window");
        window.ShowUtility();
        window.key = key;
    }

    public string key;
    public string value;

    public void OnGUI()
    {
        key = EditorGUILayout.TextField("Key:", value);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Value:", GUILayout.MaxWidth(50));

        EditorStyles.textArea.wordWrap = true;
        value = EditorGUILayout.TextArea(value, EditorStyles.textArea,
            GUILayout.Height(100), GUILayout.Width(400));
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add"))
        {
            if (LocalizationSystem.GetLocalisedValue(key) != string.Empty)
                LocalizationSystem.Replace(key, value);
            else
                LocalizationSystem.Add(key, value);
        }

        minSize = new Vector2(460, 250);
        maxSize = minSize;
    }
}
