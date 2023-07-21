using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AutoBackground))]
public class AutoBackgroundInspector : Editor
{
    private AutoBackground autoBackground;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        autoBackground = this.target as AutoBackground;
        autoBackground.wideHeightRate = EditorGUILayout.Slider("宽高比:",autoBackground.wideHeightRate, 0, 5);
        Application.isEditor
    }
}