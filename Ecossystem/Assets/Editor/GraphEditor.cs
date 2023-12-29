using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GraphDrawer))]
public class GraphEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("DrawGraph"))
        {
            GraphDrawer gd = (GraphDrawer)target;
            gd.DrawGraphInEditor();
        }
    }
}
