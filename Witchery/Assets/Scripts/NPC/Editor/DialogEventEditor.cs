using UnityEditor;
using UnityEngine;

/// <summary>
/// refreshes dialog in unity editor 
/// </summary>
[CustomEditor(typeof(DialogResponseEvents))]
public class DialogEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogResponseEvents responseEvents = (DialogResponseEvents)target;

        if (GUILayout.Button("Refresh"))
        {
            responseEvents.OnValidate();
        }
    }
}
