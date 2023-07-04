using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FireworkSpawner))]
public class FireworkSpawnerEditor : UnityEditor.Editor
{
    FireworkSpawner spawner;
    SerializedProperty prefabs;

    void OnEnable()
    {
        prefabs = serializedObject.FindProperty("fireworkPrefabs");
        spawner = (FireworkSpawner)target;
        spawner.UpdateSpawnTable();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField($"Total weight: {spawner.TotalWeight}");
        EditorGUILayout.PropertyField(prefabs);
        
        if (serializedObject.ApplyModifiedProperties())
        {
            spawner.UpdateSpawnTable();
        }
    }
}
