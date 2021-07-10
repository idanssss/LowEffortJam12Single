using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Map))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Map map = (Map)target;

        base.OnInspectorGUI();

        if (GUILayout.Button("New Seed"))
            map.GenerateSeed();
    }
}
