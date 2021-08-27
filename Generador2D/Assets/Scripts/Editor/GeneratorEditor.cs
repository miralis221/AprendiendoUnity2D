using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]

public class GeneratorEditor : Editor
{
     public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Generator generator =  (Generator)target;

        if(GUILayout.Button("Generar Mapa") == true)
        {
            generator.GenerateMap();
        }

        if(GUILayout.Button("Limpiar Mapa") == true)
        {
            generator.ClearMap();
           
        }
    }
}
