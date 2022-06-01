using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Tiled))]
public class Harita : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Tiled myScript = (Tiled)target;
        if(GUILayout.Button("Oluştur"))
        {
            myScript.HaritaOlustur();
        }
        
    }
}