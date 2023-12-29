using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(PlobSummoning))]
public class VegetationSpawningEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlobSummoning plobSummoning = (PlobSummoning) target;

        if (GUILayout.Button("Spawn Plobs"))
        {
            plobSummoning.Summon();
        }
    }
}
