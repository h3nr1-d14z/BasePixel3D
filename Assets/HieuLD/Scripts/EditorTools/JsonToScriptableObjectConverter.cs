using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;

public class JsonToScriptableObjectConverter : EditorWindow
{
    private string jsonInput = "";
    private LevelData scriptableObject;

    [MenuItem("HieuLD/Json to ScriptableObject Converter")]
    public static void ShowWindow()
    {
        GetWindow<JsonToScriptableObjectConverter>("JSON to ScriptableObject");
    }

    void OnGUI()
    {
        GUILayout.Label("JSON to ScriptableObject Converter", EditorStyles.boldLabel);

        // Text area for JSON input
        jsonInput = EditorGUILayout.TextArea(jsonInput, GUILayout.Height(100));

        // Button to convert JSON to ScriptableObject
        if (GUILayout.Button("Convert JSON to ScriptableObject"))
        {
            ConvertJsonToScriptableObject();
        }

        // Display the ScriptableObject field
        scriptableObject = EditorGUILayout.ObjectField("ScriptableObject", scriptableObject, typeof(LevelData), false) as LevelData;
    }

    private void ConvertJsonToScriptableObject()
    {
        // Check if the scriptableObject is assigned
        if (scriptableObject == null)
        {
            Debug.LogError("Please assign a ScriptableObject first!");
            return;
        }

        try
        {
            LevelData levelData = JsonConvert.DeserializeObject<LevelData>(jsonInput);

            scriptableObject.levels.Clear();
            foreach (var item in levelData.levels)
            {
                scriptableObject.levels.Add(item);
            }
            EditorUtility.SetDirty(scriptableObject);
            Debug.Log("Conversion successful!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error converting JSON: " + e.Message);
        }
    }
}
