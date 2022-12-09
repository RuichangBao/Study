using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CustomEditorClass))]
public class CustomEditorInspector : Editor
{
    private CustomEditorClass m_target;
    public override void OnInspectorGUI()
    {
        Debug.LogError("OnInspectorGUI");
    }
}
