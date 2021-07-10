using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlatformDrawer))]
public class PlatformDrawerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlatformDrawer drawer = (PlatformDrawer)target;
        if (GUILayout.Button("Draw Platforms"))
            drawer.DrawPlatforms();

        if (GUILayout.Button("New Seed"))
            drawer.map.GenerateSeed();
    }
}
